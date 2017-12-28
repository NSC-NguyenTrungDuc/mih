//
//  AddBabyPrescriptionViewController.h
//  PHR
//
//  Created by BillyMobile on 7/21/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Base2ViewController.h"
#import "PresciptionObject.h"
#import <CTAssetsPickerController/CTAssetsPickerController.h>
#import "PHImageManager+Extension.h"
#import "ImageUpload.h"

@interface AddBabyPrescriptionViewController : Base2ViewController<UITableViewDataSource,UITableViewDelegate, UIActionSheetDelegate, IQActionSheetPickerViewDelegate,CTAssetsPickerControllerDelegate,
    UICollectionViewDelegate,UICollectionViewDataSource>
@property (weak, nonatomic) IBOutlet UILabel *lblDateTime;

@property (weak, nonatomic) IBOutlet UIButton *btnChooseTime;
@property (weak, nonatomic) IBOutlet UITextField *txtPrescriptionName;

@property (weak, nonatomic) IBOutlet UITableView *tableViewContent;
@property (weak, nonatomic) IBOutlet UILabel *lblSave;
@property (weak, nonatomic) IBOutlet UIButton *btnSaveData;

@property (nonatomic) NSMutableArray *arrayNotification;
@property (nonatomic) NSMutableArray *arrayDrug;
@property (nonatomic) NSMutableArray<ImageUpload*> *arrayUploadImages;
@property (strong, nonatomic) PresciptionObject *prescriptionItem;
@property (assign, nonatomic) BOOL isUpdate;
@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;
@property (strong, nonatomic) UIImage *imageBG;

@property (copy, nonatomic) void (^addPrescriptionCallBack)();
@property (weak, nonatomic) IBOutlet NSLayoutConstraint *constraintTableAndAdd;
@property (weak, nonatomic) IBOutlet UIView *viewAdd;
@property (weak, nonatomic) IBOutlet UIView *viewOpacity;
@property (weak, nonatomic) IBOutlet UILabel *lblUploadPrescription;
@property (weak, nonatomic) IBOutlet UICollectionView *collectionViewUploadImages;

- (IBAction)actionChooseTime:(id)sender;
- (IBAction)actionSaveData:(id)sender;

@end
