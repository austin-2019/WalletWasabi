﻿namespace Gma.QrCodeNet.Encoding
{
	public struct VersionDetail
	{
		internal int Version { get; private set; }
		internal int NumTotalBytes { get; private set; }
		internal int NumDataBytes { get; private set; }
		internal int NumECBlocks { get; private set; }

		internal VersionDetail(int version, int numTotalBytes, int numDataBytes, int numECBlocks)
			: this()
		{
			Version = version;
			NumTotalBytes = numTotalBytes;
			NumDataBytes = numDataBytes;
			NumECBlocks = numECBlocks;
		}

		internal int MatrixWidth
		{
			get
			{
				return Width(Version);
			}
		}

		internal static int Width(int version)
		{
			return 17 + (4 * version);
		}

		internal int ECBlockGroup1
		{
			get
			{
				return NumECBlocks - ECBlockGroup2;
			}
		}

		internal int ECBlockGroup2
		{
			get
			{
				return NumTotalBytes % NumECBlocks;
			}
		}

		internal int NumDataBytesGroup1
		{
			get
			{
				return NumDataBytes / NumECBlocks;
			}
		}

		internal int NumDataBytesGroup2
		{
			get
			{
				return NumDataBytesGroup1 + 1;
			}
		}

		internal int NumECBytesPerBlock
		{
			get
			{
				return (NumTotalBytes - NumDataBytes) / NumECBlocks;
			}
		}

		public override string ToString()
		{
			return Version + ";" + NumTotalBytes + ";" + NumDataBytes + ";" + NumECBlocks;
		}
	}
}
