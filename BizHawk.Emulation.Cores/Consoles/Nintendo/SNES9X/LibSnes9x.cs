﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using BizHawk.Common.BizInvoke;

namespace BizHawk.Emulation.Cores.Nintendo.SNES9X
{
	public abstract class LibSnes9x
	{
		[StructLayout(LayoutKind.Sequential)]
		public class memory_area
		{
			public IntPtr ptr;
			public int size;
		};

		[StructLayout(LayoutKind.Sequential)]
		public class frame_info
		{
			public IntPtr vptr;
			public int vpitch;
			public int vwidth;
			public int vheight;
			public IntPtr sptr;
			public int slen;
		};


		const CallingConvention CC = CallingConvention.Cdecl;

		[BizImport(CC)]
		public abstract void biz_set_sound_channels(int channels);
		[BizImport(CC)]
		public abstract void biz_set_layers(int layers);
		[BizImport(CC)]
		public abstract void biz_soft_reset();
		[BizImport(CC)]
		public abstract void biz_set_port_devices(uint left, uint right);
		[BizImport(CC)]
		public abstract bool biz_load_rom(byte[] data, int size);
		[BizImport(CC)]
		public abstract bool biz_init();
		[BizImport(CC)]
		public abstract void biz_run([In, Out] frame_info frame);
		[BizImport(CC)]
		public abstract bool biz_is_ntsc();
		[BizImport(CC)]
		public abstract void biz_get_memory_area(int which, [In, Out] memory_area mem);
	}
}
