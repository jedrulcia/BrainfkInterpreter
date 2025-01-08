using System.Diagnostics;
using System.Text;

namespace BrainfkInterpreter
{
	public class Interpreter
	{
		public int[] Memory { get; private set; }
		public int Pointer { get; private set; }
		public StringBuilder Output { get; private set; }
		private bool IsValid = true;

		public Interpreter()
		{
			Memory = new int[30000];
			Pointer = 0;
			Output = new StringBuilder();
		}

		void Execute(char command, string code, ref int instructionPointer)
		{
			switch (command)
			{
				case '>':
					Pointer = (Pointer + 1) % Memory.Length;
					break;
				case '<':
					Pointer = (Pointer - 1 + Memory.Length) % Memory.Length;
					break;
				case '+':
					Memory[Pointer]++;
					break;
				case '-':
					Memory[Pointer]--;
					break;
				case '.':
					Output.Append((char)Memory[Pointer]);
					break;
				case ',':
					Memory[Pointer] = Console.Read();
					break;
				case '[':
					if (Memory[Pointer] == 0)
					{
						int loop = 1;
						while (loop > 0)
						{
							instructionPointer++;
							if (instructionPointer >= code.Length)
							{
								IsValid = false;
								return;
							}
							if (code[instructionPointer] == '[') loop++;
							if (code[instructionPointer] == ']') loop--;
						}
					}
					break;
				case ']':
					if (Memory[Pointer] != 0)
					{
						int loop = 1;
						while (loop > 0)
						{
							instructionPointer--;
							if (instructionPointer < 0)
							{
								IsValid = false;
								return;
							}
							if (code[instructionPointer] == '[') loop--;
							if (code[instructionPointer] == ']') loop++;
						}
					}
					break;
			}
		}

		public (string text, bool isValid) Run(string code)
		{
			Output.Clear();
			IsValid = true;
			int instructionPointer = 0;

			Stopwatch stopwatch = new Stopwatch();
			stopwatch.Start();

			while (instructionPointer < code.Length)
			{
				Execute(code[instructionPointer], code, ref instructionPointer);
				instructionPointer++;

				if (stopwatch.Elapsed.TotalSeconds > 5)
				{
					return ("", false);
				}
			}

			if (Output.ToString().Length == 0)
			{
				IsValid = false;
			}

			return (Output.ToString(), IsValid);
		}
	}
}
