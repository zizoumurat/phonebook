import { Component, OnInit, VERSION, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IPersonService } from 'src/app/core/services/IPerson.service';

@Component({
    selector: 'app-add-user',
    templateUrl: './add-user.component.html',
    styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {

    public breakpoint: number; // Breakpoint observer code
    public addCusForm: FormGroup;
    wasFormChanged = false;

    constructor(
        private fb: FormBuilder,
        public dialog: MatDialog,
        private personService: IPersonService
    ) { }


    ngOnInit(): void {
        this.addCusForm = this.fb.group({
            firstName: ['', [Validators.required]],
            lastName: ['', [Validators.required]],
            company: ['', [Validators.required]]
        });

        this.breakpoint = window.innerWidth <= 600 ? 1 : 2;
    }

    public onAddCus(): void {
        this.markAsDirty(this.addCusForm);
    }

    closeDialog(): void {
        this.dialog.closeAll();
    }

    save(): void {
        if (this.addCusForm.invalid)
            return;

        this.personService.create(this.addCusForm.value)
            .subscribe((_) => {
                this.closeDialog();
            });
    }

    // tslint:disable-next-line:no-any
    public onResize(event: any): void {
        this.breakpoint = event.target.innerWidth <= 600 ? 1 : 2;
    }

    private markAsDirty(group: FormGroup): void {
        group.markAsDirty();
        // tslint:disable-next-line:forin
        for (const i in group.controls) {
            group.controls[i].markAsDirty();
        }
    }

    formChanged() {
        this.wasFormChanged = true;
    }

}