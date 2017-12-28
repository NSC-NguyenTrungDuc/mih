//
//  ProgressCourseNoteViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 10/5/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

#import "OrderModel.h"
#import "MedicineNoteModel.h"
#import "EMRPlan.h"

#import "ProgressCourseTagTableViewCell.h"
#import "TagTableViewCell.h"
#import "OrderTableViewCell.h"
#import "ProgressCourseHeaderTableViewCell.h"
#import "WebviewController.h"
#import "EMRTag.h"
#import "EMRCacheLocal.h"
#import "BaseNetworking.h"
#import "PatientClinicTableViewCell.h"
#import "PatientClinicViewModel.h"
#import "UzysAssetsPickerController.h"
#import "PHRTextField.h"

@interface ProgressCourseNoteViewController : Base2ViewController<UITextFieldDelegate, UITextViewDelegate, UzysAssetsPickerControllerDelegate,UITableViewDataSource,UITableViewDelegate>{
    
}
@property (weak, nonatomic) IBOutlet UIView *viewEmpty;
@property (weak, nonatomic) IBOutlet UITableView *tableView;
@property (weak, nonatomic) IBOutlet UITableView *tableViewClinic;
@property (weak, nonatomic) IBOutlet UITextField *textFieldStatus;
@property (weak, nonatomic) IBOutlet UILabel *lbTextEvidenceUploaded;
@property (weak, nonatomic) IBOutlet PHRTextField *txtHospitalProgress;

@property (weak, nonatomic) IBOutlet UIButton *btnUploadFile;
@property (weak, nonatomic) IBOutlet DALinedTextView *noteProgressCourse;
@property (weak, nonatomic) IBOutlet PHRDateTimeView *dateProgressCourse;

@property (weak, nonatomic) IBOutlet PHRViewUploadFile *viewProgressUploadFile;
@property (weak, nonatomic) IBOutlet UIView *viewContent;
@property (nonatomic) NSMutableIndexSet *expandedSections;
@property (weak, nonatomic) IBOutlet UIView *viewLoading;

@property (weak, nonatomic) IBOutlet UILabel *labelHospitalName;
@property (nonatomic) BOOL isClinicViewHidden;
@property (nonatomic, copy) void(^didFinishGettingDiseasesList)(NSArray* diseasesList);
@property (nonatomic, copy) void(^openShowImageViewController)(UIImage *image);
@property (nonatomic, copy) void(^openWebViewController)(UIViewController *controller);
- (void)reloadPatientClinic;

@end
