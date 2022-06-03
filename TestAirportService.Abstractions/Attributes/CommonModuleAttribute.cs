﻿using System;

namespace TestAirportService.Abstractions.Attributes
{
    /// <summary>
    /// Атрибут указывает на модуль AutoFac, используемый всегда и на проде и на тестировании.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CommonModuleAttribute : Attribute
    {
    }
}