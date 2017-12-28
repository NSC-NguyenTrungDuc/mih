//
//  PHRMStandardTableViewCell.h
//  PHR
//
//  Created by DEV-MinhNN on 10/29/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface PHRMStandardTableViewCell : UITableViewCell
@property (weak, nonatomic) IBOutlet UIView *viewContaintName;
@property (weak, nonatomic) IBOutlet UIView *viewBound;

@property (weak, nonatomic) IBOutlet UILabel *lbMedicineName;
@property (weak, nonatomic) IBOutlet UILabel *lbNumbermedicine;
@property (weak, nonatomic) IBOutlet UILabel *lbDate;

@property (weak, nonatomic) IBOutlet UILabel *lbStatusDieases;
@property (weak, nonatomic) IBOutlet UIImageView *imgMedicine;
@property (weak, nonatomic) IBOutlet UIImageView *imgSeparator;
@property (weak, nonatomic) IBOutlet UIImageView *imageClock;

@property (readwrite, assign) BOOL cellEditable;

- (void)setUpViewStyleWithMedicineNote:(MedicineNote *)obj;
- (void)setUpViewStyleWithDieasesObject:(DiseasesModel *)dieasesModel;

@end
