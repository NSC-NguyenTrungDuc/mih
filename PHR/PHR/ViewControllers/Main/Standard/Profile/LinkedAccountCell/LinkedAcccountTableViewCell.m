//
//  LinkedAcccountTableViewCell.m
//  PHR
//
//  Created by DEV-MinhNN on 12/7/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "LinkedAcccountTableViewCell.h"

static float const FontSizeTextfield = 12;

@implementation LinkedAcccountTableViewCell {
    ClinicAccount *_clinic;
    ClinicHospital *_hospital;
}

- (void)awakeFromNib {
    // Initialization code
    [self setStyleForCell];
  
    // button delete
    self.buttonDelete.layer.cornerRadius = 4;
    
    // localized
    self.lbHospital.text = kLocalizedString(kHospital);
    self.txtLinkedAcc.placeholder = kLocalizedString(kPatientCode);
    self.txtHospitalName.placeholder = kLocalizedString(kHospitalCode);
    self.txtLinkedAccPassword.placeholder = kLocalizedString(kPassword);
    [self.btnSaveLinkedAcc setTitle:kLocalizedString(kSave) forState:UIControlStateNormal];
    [self.buttonDelete setTitle:kLocalizedString(kDelete) forState:UIControlStateNormal];
}

- (void)setStyleForCell {
    [self.viewNavigation setBackgroundColor:RGBCOLOR(184.0, 184.0, 184.0)];
    [self.viewSeparatorNavi setBackgroundColor:RGBCOLOR(198.0, 198.0, 198.0)];
    
    [self.viewBoundLinkedAcc.layer setBorderWidth:1.0];
    [self.viewBoundLinkedAcc.layer setBorderColor:RGBCOLOR(184.0, 184.0, 184.0).CGColor];
    
    [self.lbHospital setFont:[FontUtils aileronRegularWithSize:14.0]];
    [self.lbHospital setText:kLocalizedString(kHospital)];
    
    [self.btnSaveLinkedAcc setTitle:kLocalizedString(kSave) forState:UIControlStateNormal];
    [self.btnSaveLinkedAcc.titleLabel setFont:[FontUtils aileronLightWithSize:11.0]];
    
    [self.txtLinkedAcc setFont:[FontUtils aileronRegularWithSize:FontSizeTextfield]];
    [self.txtLinkedAcc setTextColor:[UIColor blackColor]];
    self.txtLinkedAcc.rightViewMode = UITextFieldViewModeAlways;
    
    [self.txtHospitalName setFont:[FontUtils aileronRegularWithSize:FontSizeTextfield]];
    [self.txtHospitalName setTextColor:[UIColor blackColor]];
    
    [self.txtLinkedAccPassword setFont:[FontUtils aileronRegularWithSize:FontSizeTextfield]];
    [self.txtLinkedAccPassword setTextColor:[UIColor blackColor]];
}

- (void)setupWithState:(ClinicCellState)state expanded:(BOOL)expanding{
    UIColor *color = [self getColorByState:state];
    self.viewBoundLinkedAcc.layer.borderWidth = 1;
    self.viewBoundLinkedAcc.layer.borderColor = expanding ? [color CGColor] : [[UIColor clearColor] CGColor];
    [self.viewNavigation setBackgroundColor:color];
    switch (state) {
        case ClinicCellStateActived:{
            self.txtLinkedAccPassword.hidden = YES;
            self.viewAction.hidden = NO;
            self.txtLinkedAcc.rightView = nil;
        }
            break;
        case ClinicCellStateAddNew:{
            self.txtLinkedAccPassword.hidden = NO;
            self.viewAction.hidden = YES;
            
            // image edited
            UIImageView *image = [[UIImageView alloc] initWithFrame:CGRectMake(0, 0, 30, 30)];
            image.contentMode = UIViewContentModeCenter;
            [image setImage:[UIImage imageNamed:@"Icon_Edited.png"]];
            self.txtLinkedAcc.rightView = image;
        }
            break;
    }
    self.txtLinkedAcc.enabled = (state == ClinicCellStateAddNew);
    self.buttonSearchHospital.hidden = (state != ClinicCellStateAddNew);
    self.btnSaveLinkedAcc.hidden = (state != ClinicCellStateAddNew);
    self.btnExpand.hidden = (state == ClinicCellStateAddNew);
    //[self.btnExpand setTitle:(expanding ? @"^" : @"v") forState:UIControlStateNormal];
    self.viewContent.hidden = !expanding;
}

- (void)setupInfoWithAccount:(ClinicAccount*)account{
    if (account) {
        _clinic = account;
        self.txtLinkedAcc.text = account.patientCode;
        self.txtHospitalName.text = account.hospital.hospitalCode;
        self.lbHospital.text = account.hospital.hospitalName;
    }
}

- (void)setupInfoWithHospital:(ClinicHospital*)hospital{
    if (hospital) {
        _hospital = hospital;
        self.txtHospitalName.text = hospital.hospitalCode;
    }
}

- (IBAction)actionSave:(id)sender {
    if (!self.txtLinkedAcc.text || !self.txtHospitalName.text || !self.txtLinkedAccPassword.text) {
        return;
    }
    if (self.cellSaveAction) {
        self.cellSaveAction(self.txtLinkedAcc.text, self.txtHospitalName.text, self.txtLinkedAccPassword.text);
    }
}

- (IBAction)actionDelete:(id)sender {
    if (self.cellDeleteAction) {
        self.cellDeleteAction(_clinic.clinicId);
    }
}

- (IBAction)actionSearchHospital:(id)sender {
    if (self.cellSearchAction) {
        self.cellSearchAction();
    }
}

- (IBAction)actionExpand:(id)sender {
    if (self.cellExpandedAction) {
        self.cellExpandedAction(_clinic.clinicId);
    }
}

- (IBAction)actionLinkedAccTextFieldEndEdit:(id)sender {
    if (self.txtLinkedAcc.text.length < 9 && self.txtLinkedAcc.text.length > 0) {
        NSString *newString = @"";
        for (int i = 0; i < 9 - self.txtLinkedAcc.text.length; i++) {
            newString = [newString stringByAppendingString:@"0"];
        }
        NSString *result = [NSString stringWithFormat:@"%@%@",newString,self.txtLinkedAcc.text];
        self.txtLinkedAcc.text = result;
    }
}

- (UIColor *)getColorByState:(ClinicCellState)state{
    switch (state) {
        case ClinicCellStateAddNew:
            return [UIColor lightGrayColor];
        case ClinicCellStateActived:
            return [UIColor colorWithRed:163.0/255.0 green:200.0/255.0 blue:76.0/255.0 alpha:1.0];
        default:
            return [UIColor darkGrayColor];
    }
}

- (void)clearData{
    self.txtLinkedAcc.text = @"";
    self.txtHospitalName.text = @"";
    self.txtLinkedAccPassword.text = @"";
}

@end
