﻿// Copyright 2003-2023 by Autodesk, Inc.
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

using Autodesk.Revit.DB;
using RevitLookup.ViewModels.Objects;

namespace RevitLookup.Core.Descriptors.Extensions;

public sealed class ExtensionManager
{
    private readonly Descriptor _descriptor;
    private readonly Document _context;
    private readonly List<Descriptor> _members;

    public ExtensionManager(Descriptor descriptor, Document context, List<Descriptor> members)
    {
        _descriptor = descriptor;
        _context = context;
        _members = members;
    }

    public void Register(string name, object value)
    {
        var descriptor = new ObjectDescriptor
        {
            Type = _descriptor.Type,
            Label = name,
            Value = new SnoopableObject(_context, value)
        };

        _members.Add(descriptor);
    }

    public void Register(string group, string name, object value)
    {
        var descriptor = new ObjectDescriptor
        {
            Type = group,
            Label = name,
            Value = new SnoopableObject(_context, value)
        };

        _members.Add(descriptor);
    }
}