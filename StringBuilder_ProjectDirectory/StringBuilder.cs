using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("StringBuilder.Test")]
namespace StringBuilder
{
    internal class StringBuilder
    {
        private int lengthOfString;
        private int addCost;
        private int copyAppendCost;

        internal int LengthOfString
        {
            get { return lengthOfString; }
            private set
            {
                if (value >= 1 && value <= 100)
                {
                    lengthOfString = value;
                }
                else
                {
                    throw new Exception($"Constraint '1 <= {nameof(LengthOfString)} <= 100' validation failed.");
                }
            }
        }

        internal int AddCost
        {
            get { return addCost; }
            set
            {
                if (value >= 1 && value <= 1000)
                {
                    addCost = value;
                }
                else
                {
                    throw new Exception($"Constraint '1 <= {nameof(AddCost)} <= 1000' validation failed.");
                }
            }
        }

        internal int CopyAppendCost
        {
            get { return copyAppendCost; }
            set
            {
                if (value >= 1 && value <= 1000)
                {
                    copyAppendCost = value;
                }
                else
                {
                    throw new Exception($"Constraint '1 <= {nameof(CopyAppendCost)} <= 1000' validation failed.");
                }
            }
        }

        internal StringBuilder(int lengthOfString, int addCost, int copyAppendCost)
        {
            LengthOfString = lengthOfString;
            AddCost = addCost;
            CopyAppendCost = copyAppendCost;
        }

        internal int ComputeMinimumCost(string inputString)
        {
            int minimumCostToBuild = 0;
            inputString = inputString.ToLower();

            if (inputString.Length == LengthOfString)
            {
                int cursorPosition = 0;                         // Point to current item
                int subStringLength = 1;                        // Length of string to extract from inputString in each iteration
                int matchingIndexPosition = -1;
                string extractedPart = string.Empty;
                string outputString = string.Empty;

                void UpdateCost(int cost) { minimumCostToBuild += cost; }
                void UpdateCursor() { cursorPosition = (outputString.Length); }

                bool completeBuilding = false;
                while (outputString.Length <= LengthOfString)
                {
                    if (completeBuilding) break;
                    for (int lengthToExtract = subStringLength; lengthToExtract >= 1; lengthToExtract--)
                    {
                        if (outputString.Length == LengthOfString)
                        {
                            // Check if output string construction is complete or not, if done, signal and break away.
                            completeBuilding = true;
                            break;
                        }

                        if (cursorPosition + lengthToExtract > inputString.Length)
                            // Check if we perform a substring operation from current cursor position
                            // to a length specified in lengthToExtract ; will that exceed total input
                            // string or not. If not handled exception occurs.

                            // If exceeding = true, then we move to next iteation, reduce lengthToExtract by 1
                            // and check again.
                            continue;

                        extractedPart = inputString.Substring(cursorPosition, lengthToExtract);

                        matchingIndexPosition = -1;
                        matchingIndexPosition = outputString.IndexOf(extractedPart);
                        if (matchingIndexPosition == -1)
                        {
                            // Item (can be a single character or string) not present in outputString
                            if (extractedPart.Length > 1)
                                // Have to add one 'character'.
                                continue;

                            // Add a character to the end of String for 'AddCost' dollars.
                            outputString += extractedPart;
                            UpdateCost(AddCost);
                            UpdateCursor();
                        }
                        else
                        {
                            // Item (can be a single character or string) present in outputString
                            if (extractedPart.Length > 1)
                            {
                                // Copy any substring and add at the end 
                                outputString += outputString.Substring(matchingIndexPosition, extractedPart.Length);
                                UpdateCost(CopyAppendCost);
                                UpdateCursor();

                                // Since a substring is matched and copy-appended no need to continue in the loop
                                // and reduce lengthToExract by one and check presence. Cursor position is also
                                // updated. Start from that position next time.
                                subStringLength++;
                                break;
                            }
                            else
                            {
                                // Single character
                                if (AddCost > CopyAppendCost)
                                {
                                    // Copy any substring and add at the end 
                                    outputString += outputString.Substring(matchingIndexPosition, extractedPart.Length);
                                    UpdateCost(CopyAppendCost);
                                    UpdateCursor();
                                }
                                else
                                {
                                    // Add a character to the end of String for 'AddCost' dollars.
                                    outputString += extractedPart;
                                    UpdateCost(AddCost);
                                    UpdateCursor();
                                }
                            }
                        }
                    }
                    subStringLength++;
                }
            }
            else
            {
                throw new Exception($"Length of input string {inputString} must be equal to {LengthOfString}.");
            }
            return minimumCostToBuild;
        }
    }
}
