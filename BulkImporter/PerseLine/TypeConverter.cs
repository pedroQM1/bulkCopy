

namespace ImportManager.PerseLine
{
    internal class TypeConverter
    {
        public static object ChangeType(string value, Type type)
        {
            if(String.IsNullOrEmpty(value))return DBNull.Value;
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    bool resultBool;
                    if(value == "1" || value == "0")return value == "1" ? true : false;
                    else if (bool.TryParse(value, out resultBool))
                    return resultBool;
                    break;
                case TypeCode.Byte:
                    byte resultByte;
                    if (byte.TryParse(value, out resultByte))
                    return resultByte;
                    break;
                case TypeCode.Char:
                    char resultChar;
                    if (char.TryParse(value, out resultChar))
                    return resultChar;
                    break;
                case TypeCode.DateTime:
                    DateTime resultDateTime;
                    if (DateTime.TryParse(value, out resultDateTime))
                    return resultDateTime;
                    break;
                case TypeCode.Decimal:
                    decimal resultDecimal;
                    int lastDotIndex = value.LastIndexOf('.');
                    if(lastDotIndex > 0)
                    {
                        var newValue = value.Substring(0, lastDotIndex) + "," + value.Substring(lastDotIndex + 1);
                        if (decimal.TryParse(newValue, out resultDecimal))
                        if(resultDecimal > 0) Console.WriteLine(newValue);
                        return resultDecimal;
                    }
                    else if (decimal.TryParse(value, out resultDecimal))
                    return resultDecimal;
                    break;
                case TypeCode.Double:
                    double resultDouble;
                    if (double.TryParse(value, out resultDouble))
                    return resultDouble;
                    break;
                case TypeCode.Int16:
                    short resultShort;
                    if (short.TryParse(value, out resultShort))
                    return resultShort;
                    break;
                case TypeCode.Int32:
                    int resultInt;
                    if (int.TryParse(value, out resultInt))
                    return resultInt;
                    break;
                case TypeCode.Int64:
                    long resultLong;
                    if (long.TryParse(value, out resultLong))
                    return resultLong;
                    break;
                case TypeCode.SByte:
                    sbyte resultSByte;
                    if (sbyte.TryParse(value, out resultSByte))
                    return resultSByte;
                    break;
                case TypeCode.Single:
                    float resultFloat;
                    if (float.TryParse(value, out resultFloat))
                    return resultFloat;
                    break;
                case TypeCode.String:
                    return value;
                case TypeCode.UInt16:
                    ushort resultUShort;
                    if (ushort.TryParse(value, out resultUShort))
                    return resultUShort;
                    break;
                case TypeCode.UInt32:
                    uint resultUInt;
                    if (uint.TryParse(value, out resultUInt))
                    return resultUInt;
                    break;
                case TypeCode.UInt64:
                    ulong resultULong;
                    if (ulong.TryParse(value, out resultULong))
                    return resultULong;
                    break;
                case TypeCode.Object:
                default:
                    if (type == typeof(Guid))
                    {
                        Guid resultGuid;
                        if (Guid.TryParse(value, out resultGuid))
                        return resultGuid;
                    }
                    break;
            }

            // Se chegou aqui, a conversão falhou
            return DBNull.Value;
        }
    }
}
