//
//  PHRMStandardTableViewCell.m
//  PHR
//
//  Created by DEV-MinhNN on 10/29/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "PHRMStandardTableViewCell.h"

@implementation PHRMStandardTableViewCell

- (void)awakeFromNib {
    // Initialization code
    [self setStyleToCell];
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated {
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

#pragma mark - UI

- (void)setStyleToCell {
    [self.viewBound.layer setCornerRadius:10.0];
    [self.viewContaintName.layer setCornerRadius:10.0];
    
    [self.viewBound.layer setBorderWidth:1.0];
    [self.viewContaintName.layer setBorderWidth:1.0];
    
    [self.viewBound.layer setBorderColor:PHR_COLOR_LINE_GRAY.CGColor];
    [self.viewContaintName.layer setBorderColor:PHR_COLOR_LINE_GRAY.CGColor];
    
    [self.viewBound setBackgroundColor:PHR_COLOR_LIGHT_PINK];
    
    [self.lbMedicineName setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbNumbermedicine setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbDate setStyleRegularToLabelWithColor:PHR_COLOR_GRAY andSize:8.0];
    
    [self.lbStatusDieases setStyleRegularToLabelWithColor:PHR_COLOR_DATE_TIME andSize:14.0];
    [self.lbStatusDieases setHidden:NO];
}

- (void)setUpViewStyleWithMedicineNote:(MedicineNote *)obj {
    [self.lbStatusDieases setHidden:NO];
    
    [self.lbMedicineName setText:obj.name];
    [self.lbNumbermedicine setText:[NSString stringWithFormat:@"%d", obj.quantity]];
    [self.lbDate setText:obj.time_take_medicine];
    
    int methodValue = [obj.method intValue];
    switch (methodValue) {
        case 0:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine"]];
            break;
        case 1:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_2"]];
            break;
        case 2:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_3"]];
            break;
        case 3:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_4"]];
            break;
        case 4:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_5"]];
            break;
        case 5:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_6"]];
            break;
        case 6:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_7"]];
            break;
        case 7:
            [self.imgMedicine setImage:[UIImage imageNamed:@"Icon_Medicine_7"]];
            break;
        default:
            break;
    }
}

- (void)setUpViewStyleWithDieasesObject:(DiseasesModel *)dieasesModel {
    [self.lbStatusDieases setHidden:NO];
    [self.imgMedicine setHidden:YES];
    
    [self.imgSeparator setHidden:YES];
    [self.lbNumbermedicine setHidden:YES];
    
    [self.lbMedicineName setText:dieasesModel.disease_name];
    
    if(dieasesModel.hospital != nil){
        [self.lbStatusDieases setText:dieasesModel.hospital];
    }
    
//    [self.lbDate setStyleRegularToLabelWithColor:PHR_COLOR_GRAY andSize:8.0];
//    [self.lbDate setText:[UIUtils formatTimeStyle:[UIUtils dateFromServerTimeString:dieasesModel.datetime_record]]];
    self.lbDate.text = @"";
    self.imageClock.hidden = YES;
}

@end
