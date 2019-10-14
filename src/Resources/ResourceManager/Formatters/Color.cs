﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

namespace Microsoft.Azure.Commands.ResourceManager.Cmdlets.Formatters
{
    using System;

    public class Color : IEquatable<Color>
    {
        private const char Esc = (char)27;

        private readonly string colorCode;

        public static Color Orange => new Color($"{Esc}[38;5;208m");

        public static Color Green => new Color($"{Esc}[38;5;77m");

        public static Color Purple => new Color($"{Esc}[38;5;105m");

        public static Color Blue => new Color($"{Esc}[38;5;39m");

        public static Color Gray => new Color($"{Esc}[38;5;8m");

        public static Color Reset => new Color($"{Esc}[0m");

        private Color(string colorCode)
        {
            this.colorCode = colorCode;
        }

        public override string ToString()
        {
            return this.colorCode;
        }

        public bool Equals(Color other)
        {
            return other != null && string.Equals(colorCode, other.colorCode);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == this.GetType() && Equals((Color)obj);
        }

        public override int GetHashCode()
        {
            return colorCode != null ? colorCode.GetHashCode() : 0;
        }
    }
}
