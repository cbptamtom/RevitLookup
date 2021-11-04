#region Header

//
// Copyright 2003-2021 by Autodesk, Inc. 
//
// Permission to use, copy, modify, and distribute this software in
// object code form for any purpose and without fee is hereby granted, 
// provided that the above copyright notice appears in all copies and 
// that both that copyright notice and the limited warranty and
// restricted rights notice below appear in all supporting 
// documentation.
//
// AUTODESK PROVIDES THIS PROGRAM "AS IS" AND WITH ALL FAULTS. 
// AUTODESK SPECIFICALLY DISCLAIMS ANY IMPLIED WARRANTY OF
// MERCHANTABILITY OR FITNESS FOR A PARTICULAR USE.  AUTODESK, INC. 
// DOES NOT WARRANT THAT THE OPERATION OF THE PROGRAM WILL BE
// UNINTERRUPTED OR ERROR FREE.
//
// Use, duplication, or disclosure by the U.S. Government is subject to 
// restrictions set forth in FAR 52.227-19 (Commercial Computer
// Software - Restricted Rights) and DFAR 252.227-7013(c)(1)(ii)
// (Rights in Technical Data and Computer Software), as applicable.
//

#endregion // Header

using System.Collections;
using System.Windows.Forms;
using RevitLookup.Forms;

namespace RevitLookup.Core.Snoop.Data
{
    /// <summary>
    ///     Snoop.Data class to hold and format an Object value.
    /// </summary>
    public class Object : Data
    {
        private readonly string _mStrValue;

        protected object MVal;

        public
            Object(string label, object val)
            : base(label)
        {
            MVal = val;
            _mStrValue = Utils.ObjToLabelStr(MVal);
        }

        public override bool
            HasDrillDown
        {
            get
            {
                if (MVal == null)
                    return false;
                return true;
            }
        }

        public override string
            StrValue()
        {
            return _mStrValue;
        }

        public override Form DrillDown()
        {
            if (MVal != null)
            {
                var objs = new ArrayList();
                objs.Add(MVal);

                var form = new Objects(objs);
                return form;
            }

            return null;
        }
    }
}