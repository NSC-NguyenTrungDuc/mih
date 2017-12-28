//
//  MedicineNoteViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 10/5/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "MedicineNote.h"

@interface MedicineNoteViewController : Base2ViewController<UITextFieldDelegate, UzysAssetsPickerControllerDelegate, UITextViewDelegate>{
    
}

@property (weak, nonatomic) IBOutlet UIView *mainViewMedicine;
@property (weak, nonatomic) IBOutlet UIButton *btnUploadFile;
@property (weak, nonatomic) IBOutlet DALinedTextView *noteMedicine;

@property (weak, nonatomic) IBOutlet PHRTextField *txtNameMedicine;
@property (weak, nonatomic) IBOutlet PHRTextField *txtQuantity;
@property (weak, nonatomic) IBOutlet PHRTextField *txtDose;

@property (weak, nonatomic) IBOutlet UILabel *lbTextPrescription;
@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateTimeView;
@property (weak, nonatomic) IBOutlet PHRViewUploadFile *viewMedicineUploadFile;

@property (weak, nonatomic) IBOutlet UIImageView *mainBackground;
@property (weak, nonatomic) IBOutlet PHRButtonCombobox *btnUnit;
@property (weak, nonatomic) IBOutlet UIScrollView *scrollView;

@property (nonatomic, strong) NSString *id_medicine;

@property (nonatomic, copy) void(^addMedicineNoteCallBack)(BabyMedicineModel * type);

@end
