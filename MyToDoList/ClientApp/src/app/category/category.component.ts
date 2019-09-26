import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CategoryModel } from '../model/CategoryModel';
import { NotifyService } from '../service/notify.service';
declare var $: any;

@Component({
    selector: 'app-category',
    templateUrl: './category.component.html',
    styleUrls: ['./category.component.css']
})
export class CategoryComponent implements OnInit {
    public myCategories: CategoryModel[];
    public seletedItem: CategoryModel = { categoryID: 0, categoryName: '', createAt: new Date() };
    public titleUpdate: string = "Add new";
    isEdit: Boolean = false;

    constructor(
        private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string,
        private notify: NotifyService) {
        this.onFetchData();
    }

    onFetchData() {
        this.http.get<CategoryModel[]>(this.baseUrl + 'api/Category/GetListCategories').subscribe(result => {
            this.myCategories = result;
        });
    }

    ngOnInit() {
    }

    onSubmit(): void {
        if (this.isEdit) {
            this.http.post(this.baseUrl + 'api/Category/Update', this.seletedItem).subscribe(result => {
                this.onFetchData();
                $("#updateCategory").modal('hide');
                this.notify.success("Edit successfully");
            });
        } else {
            this.http.post(this.baseUrl + 'api/Category/AddNew', this.seletedItem).subscribe(result => {
                this.onFetchData();
                $("#updateCategory").modal('hide');
                this.notify.success("Add new successfully");
            });
        }
    }
    onConfirmDelete(): void {
        this.http.post(this.baseUrl + 'api/Category/Delete', this.seletedItem.categoryID).subscribe(result => {
            this.onFetchData();
            $('#confirmDelete').modal('hide');
            this.notify.success("Delete successfully");
        });
    }
    onShowEditCategory(category): void {
        $("#updateCategory").modal('show');
        this.isEdit = true;
        this.seletedItem = { ...category };
        this.titleUpdate = "Edit";
    }
    onShowDeleteCategory(category): void {
        $('#confirmDelete').modal('show');
        this.seletedItem = category;
    }
    onShowAddNewCategory(): void {
        $("#updateCategory").modal('show');
        this.titleUpdate = "Add new";
        this.seletedItem = { categoryID: 0, categoryName: '', createAt: new Date() };
        this.isEdit = false;
    }
}
