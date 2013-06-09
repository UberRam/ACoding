using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AC
{
    class ArithmeticCoderCS
    {
        public const uint g_FirstQuarter = 0x20000000;
        public const uint g_Half = 0x40000000;
        public const uint g_ThirdQuarter = 0x60000000;

        protected byte mBitBuffer;
        protected byte mBitCount;
        protected FileStream mFile;
        protected uint mLow;
        protected uint mHigh;
        protected uint mStep;
        protected uint mScale;
        protected uint mBuffer;

        public ArithmeticCoderCS()
        {
            mBitBuffer = 0;
            mBitCount = 0;

            mLow = 0;
            mHigh = 0x7FFFFFFF;
            mScale = 0;
            mStep = 0;

            mBuffer = 0;
        }

        public void SetFile(FileStream file)
        {
            mFile = file;
        }

        public void Encode(uint low_count, uint high_count, uint total)
        {
            mStep = (mHigh - mLow + 1) / total;

            mHigh = mLow + mStep * high_count - 1;

            mLow = mLow + mStep * low_count;

            while ((mHigh < g_Half) || (mLow >= g_Half))
            {
                if (mHigh < g_Half)
                {
                    SetBit(0);
                    mLow = mLow * 2;
                    mHigh = mHigh * 2 + 1;

                    for (; mScale > 0; mScale--)
                        SetBit(1);
                }else if(mLow >= g_Half){
                    SetBit(1);
                    mLow = (mLow - g_Half) * 2;
                    mHigh = (mHigh - g_Half) * 2 + 1;

                    for (; mScale > 0; mScale--)
                        SetBit(0);

                }
            }

            while ( (g_FirstQuarter <= mLow) && (mHigh < g_ThirdQuarter) )
            {
                mScale++;
                mLow = (mLow - g_FirstQuarter) * 2;
                mHigh = (mHigh - g_FirstQuarter) * 2 + 1;
            }
        }

        public void EncodeFinish()
        {
            if (mLow < g_FirstQuarter)
            {
                SetBit(0);

                for (int i = 0; i < mScale + 1; i++)
                    SetBit(1);
            }
            else
            {
                SetBit(1);
            }

            SetBitFlush();
        }

        public void DecodeStart()
        {
            for (int i = 0; i < 31; i++)
                mBuffer = (mBuffer << 1) | GetBit();
        }

        public uint DecodeTarget(uint total)
        {
            mStep = (mHigh - mLow + 1) / total;

            return (mBuffer - mLow) / mStep;
        }

        public void Decode(uint low_count, uint high_count)
        {
            mHigh = mLow + high_count * mStep - 1;

            mLow = mLow + low_count * mStep;

            while ((mHigh < g_Half) || (mLow >= g_Half))
            {
                if (mHigh < g_Half)
                {
                    mLow = mLow * 2;
                    mHigh = mHigh * 2 + 1;
                    mBuffer = mBuffer * 2 + GetBit();
                }
                else if (mLow >= g_Half)
                {
                    mLow = (mLow - g_Half) * 2;
                    mHigh = (mHigh - g_Half) * 2 + 1;
                    mBuffer = (mBuffer - g_Half) * 2 + GetBit();
                }
                mScale = 0;
            }

            while ((g_FirstQuarter <= mLow) && (mHigh < g_ThirdQuarter))
            {
                mScale++;
                mLow = (mLow - g_FirstQuarter) * 2;
                mHigh = (mHigh - g_FirstQuarter) * 2 + 1;
                mBuffer = (mBuffer - g_FirstQuarter) * 2 + GetBit();
            }
        }

        protected void SetBit(uint bit)
        {
            mBitBuffer = (byte)( ((uint)mBitBuffer << 1) | bit );
            mBitCount++;

            if (mBitCount == 8)
            {
                mFile.WriteByte(mBitBuffer);
                mBitCount = 0;
            }
            
        }

        protected void SetBitFlush()
        {
            while (mBitCount != 0)
            {
                SetBit(0);
            }
        }

        protected uint GetBit()
        {
            if (mBitCount == 0)
            {
                int readInt = mFile.ReadByte();
                if (readInt == -1)// EOF
                    mBitBuffer = 0;
                else
                    mBitBuffer = (byte)readInt;
                
                mBitCount = 8;
            }

            uint bit = (uint)mBitBuffer >> 7;
            mBitBuffer = (byte)( (uint)mBitBuffer << 1 );
            mBitCount--;

            return bit;
        }
    }
}
