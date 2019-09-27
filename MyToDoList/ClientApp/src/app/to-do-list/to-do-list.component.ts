import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ToDoListModel, ToDoStatusValue } from '../model/ToDoListModel';
import { CategoryModel } from '../model/CategoryModel';
import { NotifyService } from '../service/notify.service';
declare var $: any;

@Component({
    selector: 'app-to-do-list',
    templateUrl: './to-do-list.component.html',
    styleUrls: ['./to-do-list.component.css']
})
export class ToDoListComponent implements OnInit {
    public myToDoList: ToDoListModel[];
    public toDoStatusValue: ToDoStatusValue[];
    public categories: CategoryModel[];
    public titleUpdate: string = 'Add new';
    public isEdit: boolean = false;
    public selectedItem: ToDoListModel = <ToDoListModel>{};


    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private notify: NotifyService
    ) {
        this.onFetchData();
        http.get<ToDoStatusValue[]>(baseUrl + 'api/ToDoList/GetToDoStatusValue').subscribe(result => {
            this.toDoStatusValue = result;
        }, error => console.error(error));
        http.get<CategoryModel[]>(baseUrl + 'api/Category/GetAvailable').subscribe(result => {
            this.categories = result;
        });
    }

    ngOnInit() {
    }

    onDeleteToDo(): void {
        this.http.post(this.baseUrl + 'api/ToDoList/DeleteToDo', this.selectedItem.toDoID).subscribe(result => {
            if (result) {
                this.notify.notify(result);
                this.onFetchData();
                $('#confirmDelete').modal('hide');
            }
        }, error => {
            this.notify.error(error);
        });
    }

    onFetchData(): void {
        this.http.get<ToDoListModel[]>(this.baseUrl + 'api/ToDoList/GetListToDos').subscribe(result => {
            this.myToDoList = result;
        }, error => console.error(error));
    }


    onSubmit() {
        if (this.isEdit) {
            this.http.post(this.baseUrl + 'api/ToDoList/EditToDo', this.selectedItem).subscribe(result => {
                if (result) {
                    this.notify.notify(result);
                    this.onFetchData();
                    $('#updateToDo').modal('hide');
                }
            }, error => {
                this.notify.error(error);
            });
        } else {
            this.http.post(this.baseUrl + 'api/ToDoList/AddToDo', this.selectedItem).subscribe(result => {
                if (result) {
                    this.onFetchData();
                    $('#updateToDo').modal('hide');
                    this.notify.success("Add new successfully");
                } else {
                    this.notify.error("Add new failed");
                }
            }, error => {
                this.notify.error(error);
            });
        }
    }
    onShowAddNew(): void {
        this.isEdit = false;
        this.titleUpdate = 'Add new';
        this.selectedItem = { toDoStatus: 10 } as ToDoListModel;
        if (this.categories && this.categories.length > 0) {
            this.selectedItem.categoryID = this.categories[0].categoryID;
        }
    }
    onShowEdit(toDo) {
        this.isEdit = true;
        this.titleUpdate = 'Edit';
        this.selectedItem = { ...toDo };
        console.log(this.selectedItem);
        $('#updateToDo').modal('show');
    }
    onShowConfirmDelete(toDo) {
        this.selectedItem = toDo;
        $('#confirmDelete').modal('show');
    }
}
