# Interactive Sorting Application

## Overview
A C# console application implementing an interactive, user-guided sorting mechanism using **SOLID** and **OOP** principles. This application allows sorting 1-26 characters through direct user comparisons, following an algorithmic approach. The primary goal is to sort the list by asking the user the **minimum number of questions** required.

## Architecture and Design

**SOLID Principles**  
- **Single Responsibility**: Each class has a distinct, focused purpose.  
- **Dependency Inversion**: `ElementSorter` depends on `UserInteraction` via constructor injection.  
- **Open/Closed**: Sorting strategy is extensible without modifying existing code.  

**OOP Characteristics**  
- **Encapsulation**: Through private methods and fields.  
- **Modular Design**: Clear separation of responsibilities.  
- **Recursive Sorting Algorithm**: Demonstrates polymorphic behavior.  

## Workflow
1. User specifies the number of elements to sort (1-26).  
2. The application generates the initial character list.  
3. Sorting is performed interactively through user-guided comparisons.  
4. Sorted results are displayed.  

## Example Usage
```plaintext
Kaç eleman sıralamak istiyorsunuz? (1-26 arasında bir sayı girin)
5
Sıralanacak elemanlar:
A
B
C
D
E

Hangisi daha küçük? A mı yoksa B mi?
A
Hangisi daha küçük? C mi yoksa D mi?
C
... (continues with user comparisons)

Sıralama tamamlandı:
A
B
C
D
E
```
