//
//  ProfileViewController.h
//  PHR
//
//  Created by DEV-MinhNN on 9/30/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "AccordionView.h"
#import "ProfileStandard.h"
#import "ClinicAccount.h"
#import <CTAssetsPickerController/CTAssetsPickerController.h>
#import "PHImageManager+Extension.h"

@interface ProfileViewController : Base2ViewController <AccordionViewDelegate, UITextFieldDelegate, UIAlertViewDelegate, CTAssetsPickerControllerDelegate> {
    AccordionView *accordionView;
    NSMutableArray *arrayTextProfileInfo;
}

@property (weak, nonatomic) IBOutlet UIView *viewProfile;

@property (nonatomic, strong) PHRTextField *txtName;
@property (nonatomic, strong) PHRButtonCombobox *comboboxGender;
@property (nonatomic, strong) PHRTextField *txtNameKana;

@property (nonatomic, strong) PHRTextField *txtBirthday;
@property (nonatomic, strong) PHRTextField *txtZipCode;
@property (nonatomic, strong) PHRTextField *txtPrefecture;

@property (nonatomic, strong) PHRTextField *txtCity;
@property (nonatomic, strong) PHRTextField *txtAddress;
@property (nonatomic, strong) PHRTextField *txtOccupation;

@property (nonatomic, strong) UIButton *btnCamera;
@property (nonatomic, strong) UIImageView *imgAvatar;

@property (weak, nonatomic) IBOutlet UIImageView *imageBackground;

- (void)setProfile:(ProfileStandard*)profile;

@end
