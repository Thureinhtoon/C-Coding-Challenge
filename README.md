# Phone Keypad Text Converter

This project implements an old phone keypad text input system, similar to the T9 system used in traditional mobile phones. It converts number sequences into text based on the old phone keypad layout.

## Features

- Converts number sequences to text using old phone keypad mapping
- Supports backspace functionality (using \*)
- Handles multiple presses of the same button
- Includes comprehensive test cases
- Interactive mode for custom input testing

## How to Run

1. Make sure you have .NET SDK installed
2. Clone this repository
3. Navigate to the project directory
4. Run the project:
   ```bash
   dotnet run
   ```

## Input Format

- Each input must end with #
- Use spaces or pauses between same-button letters
- Use \* for backspace
- Number mapping:
  - 2 = ABC
  - 3 = DEF
  - 4 = GHI
  - 5 = JKL
  - 6 = MNO
  - 7 = PQRS
  - 8 = TUV
  - 9 = WXYZ
  - 0 = space

## Example Usage

```
Input: 4433555 555666#
Output: HELLO

Input: 7 555 33 2 7777 33 0 44 444 777 33 0 6 33#
Output: PLEASE HIRE ME
```

## Testing

The program includes several test cases that demonstrate its functionality. These tests run automatically when you start the program.
