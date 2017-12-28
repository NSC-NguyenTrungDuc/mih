//
//  ProfileChildrenViewController.h
//  PHR
//
//  Created by SonNV1368 on 10/5/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import "Base2ViewController.h"
#import "PHRTextField.h"
#import "ProfileBaby.h"
#import <CTAssetsPickerController/CTAssetsPickerController.h>
#import "PHImageManager+Extension.h"

@interface ProfileChildrenViewController : Base2ViewController<UITextFieldDelegate, CTAssetsPickerControllerDelegate, PHRButtonComboboxDelegate> {
    
}
@property (strong, nonatomic) IBOutlet UIImageView *imageAvatar;
@property (strong, nonatomic) IBOutlet PHRTextField *textFieldName;
@property (strong, nonatomic) IBOutlet PHRTextField *textFieldNickName;
@property (strong, nonatomic) IBOutlet PHRTextField *textFieldNameKana;
@property (strong, nonatomic) IBOutlet PHRTextField *textFieldBirthday;
@property (weak, nonatomic) IBOutlet PHRButtonCombobox *comboboxRelationship;

@property (strong, nonatomic) IBOutlet PHRTextField *textFieldHeight;
@property (strong, nonatomic) IBOutlet PHRTextField *textFieldWeight;
@property (weak, nonatomic) IBOutlet UIImageView *mainBackground;
@property (weak, nonatomic) IBOutlet UIActivityIndicatorView *viewIndicator;

- (IBAction)touchTakePhoto:(id)sender;
- (IBAction)actionChangeBirthday:(id)sender;
- (IBAction)actionChoiceRelationship:(id)sender;
- (void)setProfileBaby:(ProfileBaby*)baby;

@end
