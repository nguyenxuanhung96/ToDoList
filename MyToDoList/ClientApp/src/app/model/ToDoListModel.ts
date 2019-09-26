export interface ToDoListModel {
    toDoID: number,
    toDoTitle: string,
    toDoContent: string,
    toDoStatus: number,
    categoryID: number,
    toDoStatusText: string,
}

export interface ToDoStatusValue {
    statusValue: number,
    statusName: string,
}
