import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IContactInformationService } from 'src/app/core/services/IContact-info.service';

@Component({
    selector: 'app-add-contact',
    templateUrl: './add-contact.component.html',
    styleUrls: ['./add-contact.component.css']
})

export class AddContactComponent implements OnInit {

    public breakpoint: number; // Breakpoint observer code
    public addForm: FormGroup;
    wasFormChanged = false;

    constructor(
        private fb: FormBuilder,
        public dialog: MatDialog,
        private service: IContactInformationService,
        @Inject(MAT_DIALOG_DATA) public data: string
    ) { }


    ngOnInit(): void {
        this.addForm = this.fb.group({
            personId:[this.data, [Validators.required]],
            phoneNumber: ['', [Validators.required]],
            email: ['', [Validators.required, Validators.email]],
            location: ['', [Validators.required]]
        });
        this.breakpoint = window.innerWidth <= 600 ? 1 : 2;
    }

    public onAddCus(): void {
        this.markAsDirty(this.addForm);
    }

    closeDialog(): void {
        this.dialog.closeAll();
    }

    save(): void {
        if (this.addForm.invalid)
            return;

        this.service.create(this.addForm.value)
            .subscribe((_) => {
                this.closeDialog();
            });
    }

    // tslint:disable -next-line:no-any
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