# DAY 16 tasks

## TASK

Разработать обобщенный класс-коллекцию BinarySearchTree (бинарное дерево поиска). Предусмотреть возможности использования подключаемого интерфейса для реализации отношения порядка. Реализовать три способа обхода дерева: прямой (preorder), поперечный (inorder), обратный (postorder): для реализации использовать блок-итератор (yield). Протестировать разработанный класс, используя следующие типы:

* System.Int32 (использовать сравнение по умолчанию и подключаемый компаратор);

* System.String (использовать сравнение по умолчанию и подключаемый компаратор);

* пользовательский класс Book, для объектов которого реализовано отношения порядка (использовать сравнение по умолчанию и подключаемый компаратор);

* пользовательскую структуру Point, для объектов которого не реализовано отношения порядка (использовать подключаемый компаратор).

### What is done

* [Дерево](https://github.com/anayeremeiko/NET1.A.2018.Yeremeiko/blob/master/NET1.A.2018.Yeremeiko.16/Collections/BinarySearchTree.cs)

* [Тесты](https://github.com/anayeremeiko/NET1.A.2018.Yeremeiko/blob/master/NET1.A.2018.Yeremeiko.16/Collections.Tests/BinarySearchTreeTests.cs)