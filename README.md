# DateParser
This is Console application (.Net Core) with NUnit tests.

Program takes two arguments (dates) in proper formats as input, validates them and returns scope of dates in chronological order.

Example usage with expected results printed in console are presented below:

program.exe 01.01.2017 05.01.2017
01 - 05.01.2017

program.exe 01.01.2017 05.02.2017
01.01 - 05.02.2017

program.exe 01.01.2016 05.01.2017
01.01.2016 - 05.01.2017
