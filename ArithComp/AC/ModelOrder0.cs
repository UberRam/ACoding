using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AC
{
    class ModelOrder0 : AbstractModel
    {
        protected uint[] mCumCount = new uint[257];
        protected uint mTotal;

        public ModelOrder0()
        {
            mTotal = 257;
            for (uint i = 0; i < 257; i++)
                mCumCount[i] = 1;
        }

        protected override void Encode()
        {
            int readInt=0;
            while (readInt != -1)//EOF
            {
                byte symbol;
                readInt = mSource.ReadByte();
                symbol = (byte)readInt;
                if (readInt != -1)//EOF
                {
                    uint low_count = 0;
                    
                    for (byte j = 0; j < symbol; j++)
                    {
                        low_count += mCumCount[j];
                    }

                    mAC.Encode(low_count, low_count + mCumCount[symbol], mTotal);

                    mCumCount[symbol]++;
                    mTotal++;
                }
            }

            mAC.Encode(mTotal - 1, mTotal, mTotal);
        }

        protected override void Decode()
        {
            uint symbol; // uint instead of byte because it must be able to contain 256 as terminator

            do
            {
                uint value;

                value = mAC.DecodeTarget(mTotal);

                uint low_count=0;
                for( symbol=0; low_count + mCumCount[symbol] <= value; symbol++ )
                    low_count += mCumCount[symbol];

                // Write symbol, if it was not terminator
                if (symbol < 256)
                    mTarget.WriteByte((byte)symbol);

                mAC.Decode( low_count, low_count + mCumCount[symbol] );

                mCumCount[symbol]++;
                mTotal++;
            }while(symbol != 256); // until terminator
        }
    }
}
