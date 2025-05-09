// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace ILCompiler.DependencyAnalysis
{
    public enum SectionType
    {
        ReadOnly,
        Writeable,
        Executable,
        Uninitialized,
        Debug,
        UnwindData,
    }

    /// <summary>
    /// Specifies the object file section a node will be placed in; ie "text" or "data"
    /// </summary>
    public class ObjectNodeSection
    {
        public string Name { get; }
        public SectionType Type { get; }
        public string ComdatName { get; }

        public ObjectNodeSection(string name, SectionType type, string comdatName)
        {
            Name = name;
            Type = type;
            ComdatName = comdatName;
        }

        public ObjectNodeSection(string name, SectionType type) : this(name, type, null)
        { }

        public static readonly ObjectNodeSection XDataSection = new ObjectNodeSection("xdata", SectionType.ReadOnly);
        public static readonly ObjectNodeSection DataSection = new ObjectNodeSection("data", SectionType.Writeable);
        public static readonly ObjectNodeSection ReadOnlyDataSection = new ObjectNodeSection("rdata", SectionType.ReadOnly);
        public static readonly ObjectNodeSection FoldableReadOnlyDataSection = new ObjectNodeSection("rdata", SectionType.ReadOnly);
        public static readonly ObjectNodeSection TextSection = new ObjectNodeSection("text", SectionType.Executable);
        public static readonly ObjectNodeSection TLSSection = new ObjectNodeSection("tdata", SectionType.Writeable);
        public static readonly ObjectNodeSection BssSection = new ObjectNodeSection("bss", SectionType.Uninitialized);
        public static readonly ObjectNodeSection HydrationTargetSection = new ObjectNodeSection("hydrated", SectionType.Uninitialized);
        public static readonly ObjectNodeSection ManagedCodeWindowsContentSection = new ObjectNodeSection(".managedcode$I", SectionType.Executable);
        public static readonly ObjectNodeSection ManagedCodeUnixContentSection = new ObjectNodeSection("__managedcode", SectionType.Executable);

        // Section name on Windows has to be alphabetically less than the ending WindowsUnboxingStubsRegionNode node, and larger than
        // the begining WindowsUnboxingStubsRegionNode node, in order to have proper delimiters to the begining/ending of the
        // stubs region, in order for the runtime to know where the region starts and ends.
        public static readonly ObjectNodeSection UnboxingStubWindowsContentSection = new ObjectNodeSection(".unbox$M", SectionType.Executable);
        public static readonly ObjectNodeSection UnboxingStubUnixContentSection = new ObjectNodeSection("__unbox", SectionType.Executable);

        public static readonly ObjectNodeSection ModulesWindowsContentSection = new ObjectNodeSection(".modules$I", SectionType.ReadOnly);
        public static readonly ObjectNodeSection ModulesUnixContentSection = new ObjectNodeSection("__modules", SectionType.Writeable);
    }
}
