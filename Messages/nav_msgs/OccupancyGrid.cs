using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.InteropServices;
using uint8 = System.Byte;
using Messages.geometry_msgs;
using Messages.sensor_msgs;
using Messages.actionlib_msgs;

using Messages.std_msgs;
using String=System.String;

namespace Messages.nav_msgs
{
#if !TRACE
    [System.Diagnostics.DebuggerStepThrough]
#endif
    public class OccupancyGrid : IRosMessage
    {

			public Header header; //woo
			public Messages.nav_msgs.MapMetaData info; //woo
			public sbyte[] data;


        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string MD5Sum() { return "3381f2d731d4076ec5c71b0759edbe4e"; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool HasHeader() { return true; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsMetaType() { return true; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override string MessageDefinition() { return @"Header header
MapMetaData info
int8[] data"; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override MsgTypes msgtype() { return MsgTypes.nav_msgs__OccupancyGrid; }
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override bool IsServiceComponent() { return false; }

        [System.Diagnostics.DebuggerStepThrough]
        public OccupancyGrid()
        {
            
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public OccupancyGrid(byte[] SERIALIZEDSTUFF)
        {
            Deserialize(SERIALIZEDSTUFF);
        }

        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public OccupancyGrid(byte[] SERIALIZEDSTUFF, ref int currentIndex)
        {
            Deserialize(SERIALIZEDSTUFF, ref currentIndex);
        }



        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override void Deserialize(byte[] SERIALIZEDSTUFF, ref int currentIndex)
        {
            int arraylength=-1;
            bool hasmetacomponents = false;
            object __thing;
            int piecesize=0;
            byte[] thischunk, scratch1, scratch2;
            IntPtr h;
            
            //header
            header = new Header(SERIALIZEDSTUFF, ref currentIndex);
            //info
            info = new Messages.nav_msgs.MapMetaData(SERIALIZEDSTUFF, ref currentIndex);
            //data
            hasmetacomponents |= false;
            arraylength = BitConverter.ToInt32(SERIALIZEDSTUFF, currentIndex);
            currentIndex += Marshal.SizeOf(typeof(System.Int32));
            if (data == null)
                data = new sbyte[arraylength];
            else
                Array.Resize(ref data, arraylength);
            for (int i=0;i<data.Length; i++) {
                //data[i]
                piecesize = Marshal.SizeOf(typeof(sbyte));
                h = IntPtr.Zero;
                if (SERIALIZEDSTUFF.Length - currentIndex != 0)
                {
                    h = Marshal.AllocHGlobal(piecesize);
                    Marshal.Copy(SERIALIZEDSTUFF, currentIndex, h, piecesize);
                }
                if (h == IntPtr.Zero) throw new Exception("Alloc failed");
                data[i] = (sbyte)Marshal.PtrToStructure(h, typeof(sbyte));
                Marshal.FreeHGlobal(h);
                currentIndex+= piecesize;
            }
        }

        [System.Diagnostics.DebuggerStepThrough]
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public override byte[] Serialize(bool partofsomethingelse)
        {
            int currentIndex=0, length=0;
            bool hasmetacomponents = false;
            byte[] thischunk, scratch1, scratch2;
            List<byte[]> pieces = new List<byte[]>();
            GCHandle h;
            
            //header
            if (header == null)
                header = new Header();
            pieces.Add(header.Serialize(true));
            //info
            if (info == null)
                info = new Messages.nav_msgs.MapMetaData();
            pieces.Add(info.Serialize(true));
            //data
            hasmetacomponents |= false;
            if (data == null)
                data = new sbyte[0];
            pieces.Add(BitConverter.GetBytes(data.Length));
            for (int i=0;i<data.Length; i++) {
                //data[i]
                scratch1 = new byte[Marshal.SizeOf(typeof(sbyte))];
                h = GCHandle.Alloc(scratch1, GCHandleType.Pinned);
                Marshal.StructureToPtr(data[i], h.AddrOfPinnedObject(), false);
                h.Free();
                pieces.Add(scratch1);
            }
            //combine every array in pieces into one array and return it
            int __a_b__f = pieces.Sum((__a_b__c)=>__a_b__c.Length);
            int __a_b__e=0;
            byte[] __a_b__d = new byte[__a_b__f];
            foreach(var __p__ in pieces)
            {
                Array.Copy(__p__,0,__a_b__d,__a_b__e,__p__.Length);
                __a_b__e += __p__.Length;
            }
            return __a_b__d;
        }

        public override void Randomize()
        {
            int arraylength=-1;
            Random rand = new Random();
            int strlength;
            byte[] strbuf, myByte;
            
            //header
            header = new Header();
            header.Randomize();
            //info
            info = new Messages.nav_msgs.MapMetaData();
            info.Randomize();
            //data
            arraylength = rand.Next(10);
            if (data == null)
                data = new sbyte[arraylength];
            else
                Array.Resize(ref data, arraylength);
            for (int i=0;i<data.Length; i++) {
                //data[i]
                data[i] = (SByte)(rand.Next(255) - 127);
            }
        }

        public override bool Equals(IRosMessage ____other)
        {
            if (____other == null) return false;
            bool ret = true;
            nav_msgs.OccupancyGrid other = (Messages.nav_msgs.OccupancyGrid)____other;

            ret &= header.Equals(other.header);
            ret &= info.Equals(other.info);
            if (data.Length != other.data.Length)
                return false;
            for (int __i__=0; __i__ < data.Length; __i__++)
            {
                ret &= data[__i__] == other.data[__i__];
            }
            // for each SingleType st:
            //    ret &= {st.Name} == other.{st.Name};
            return ret;
        }
    }
}
