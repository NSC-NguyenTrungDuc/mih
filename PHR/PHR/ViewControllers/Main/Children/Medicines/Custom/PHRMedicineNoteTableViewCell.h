//
//  PHRMedicineNoteTableViewCell.h
//  PHR
//
//  Created by DEV-MinhNN on 10/28/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SWTableViewCell.h"

@interface PHRMedicineNoteTableViewCell : SWTableViewCell {
    UILabel *_nameMedicine;
    UILabel *_numberMedicine;
    UIImageView *_imgIconMedicine;
    UIImageView *_divSeparator;
}

@property (weak, nonatomic) IBOutlet UIView *viewContanit;
@property (weak, nonatomic) IBOutlet UILabel *lbTime;
@property (weak, nonatomic) IBOutlet UIImageView *imgSliderBar;

@property (weak, nonatomic) IBOutlet UIView *viewCurverBig;
@property (weak, nonatomic) IBOutlet UIView *viewCurverSmall;
@property (weak, nonatomic) IBOutlet UILabel *lbNameMedicine;

@property (weak, nonatomic) IBOutlet UIImageView *imgTimeNote;
@property (weak, nonatomic) IBOutlet UIImageView *imgClock;
@property (weak, nonatomic) IBOutlet UIImageView *imgMedicine;

@property (weak, nonatomic) IBOutlet UILabel *lbNameDiaper;
@property (weak, nonatomic) IBOutlet UILabel *lbDiaperState;
@property (weak, nonatomic) IBOutlet UILabel *lbNumberMedicine;

@property (readwrite, assign) BOOL cellEditable;

- (void)setDataMedicineToCell:(MedicineNote *)medicine;
- (void)setDataDiaperToCell:(Diaper *)diaper;

@end
