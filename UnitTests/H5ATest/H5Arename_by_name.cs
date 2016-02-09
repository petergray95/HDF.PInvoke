﻿/* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
 * Copyright by The HDF Group.                                               *
 * Copyright by the Board of Trustees of the University of Illinois.         *
 * All rights reserved.                                                      *
 *                                                                           *
 * This file is part of HDF5.  The full HDF5 copyright notice, including     *
 * terms governing use, modification, and redistribution, is contained in    *
 * the files COPYING and Copyright.html.  COPYING can be found at the root   *
 * of the source code distribution tree; Copyright.html can be found at the  *
 * root level of an installed copy of the electronic HDF5 document set and   *
 * is linked from the top-level documents page.  It can also be found at     *
 * http://hdfgroup.org/HDF5/doc/Copyright.html.  If you do not have          *
 * access to either file, you may request a copy from help@hdfgroup.org.     *
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * */

using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HDF.PInvoke;

using htri_t = System.Int32;

#if HDF5_VER1_10
using hid_t = System.Int64;
#else
using hid_t = System.Int32;
#endif

namespace UnitTests
{
    public partial class H5ATest
    {
        [TestMethod]
        public void H5Arename_by_nameTest1()
        {
            hid_t att = H5A.create(m_v2_test_file, "A", H5T.IEEE_F64LE,
                m_space_scalar);
            Assert.IsTrue(att >= 0);
            Assert.IsTrue(H5A.close(att) >= 0);
            Assert.IsTrue(H5A.rename_by_name(m_v2_test_file, ".", "A", "new A")
                >= 0);
            Assert.IsFalse(
                H5A.rename_by_name(m_v2_test_file, ".", "A", "new A") >= 0);

            att = H5A.create(m_v0_test_file, "A", H5T.IEEE_F64LE,
                m_space_scalar);
            Assert.IsTrue(att >= 0);
            Assert.IsTrue(H5A.close(att) >= 0);
            Assert.IsTrue(
                H5A.rename_by_name(m_v0_test_file, ".", "A", "new A") >= 0);
        }

        [TestMethod]
        public void H5Arename_by_nameTest2()
        {
            Assert.IsFalse(
                H5A.rename_by_name(
                Utilities.RandomInvalidHandle(), ".", "foo", "bar") >= 0);
            Assert.IsFalse(
                H5A.rename_by_name(m_v0_test_file, ".", "foo", "bar") >= 0);
        }
    }
}