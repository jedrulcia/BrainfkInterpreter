using System.Text;

namespace BrainfkInterpreter
{
	public class Interpreter
	{
		public int[] Memory { get; private set; }
		public int Pointer { get; private set; }
		public StringBuilder Output { get; private set; }

		public Interpreter()
		{
			Memory = new int[30000];
			Pointer = 0;
			Output = new StringBuilder();
		}

		public void Execute(char command, string code, ref int instructionPointer)
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
					Memory[Pointer] = Console.Read(); // Wczytanie jednego znaku
					break;
				case '[':
					if (Memory[Pointer] == 0)
					{
						// Skocz na koniec pętli
						int loop = 1;
						while (loop > 0)
						{
							instructionPointer++;
							if (instructionPointer >= code.Length) throw new Exception("Brakujący ']'.");
							if (code[instructionPointer] == '[') loop++;
							if (code[instructionPointer] == ']') loop--;
						}
					}
					break;
				case ']':
					if (Memory[Pointer] != 0)
					{
						// Skocz na początek pętli
						int loop = 1;
						while (loop > 0)
						{
							instructionPointer--;
							if (instructionPointer < 0) throw new Exception("Brakujący '['.");
							if (code[instructionPointer] == '[') loop--;
							if (code[instructionPointer] == ']') loop++;
						}
					}
					break;
			}
		}

		public void Run(string code)
		{
			Output.Clear();
			int instructionPointer = 0;

			while (instructionPointer < code.Length)
			{
				Execute(code[instructionPointer], code, ref instructionPointer);
				instructionPointer++;
			}

			Console.WriteLine(Output.ToString());
		}
	}
}
