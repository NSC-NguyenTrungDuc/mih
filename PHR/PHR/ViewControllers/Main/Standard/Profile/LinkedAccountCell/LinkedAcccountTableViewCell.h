//
//  LinkedAcccountTableViewCell.h
//  PHR
//
//  Created by DEV-MinhNN on 12/7/15.
//  Copyright © 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

typedef NS_ENUM(NSInteger, ClinicCellState) {
    ClinicCellStateAddNew,
    ClinicCellStateActived
};

@interface LinkedAcccountTableViewCell : UITableViewCell<UITextFieldDelegate> {
    
}

@property (nonatomic, copy) void(^cellExpandedAction)(NSString *clinicId);
@property (nonatomic, copy) void(^cellSetActiveAction)(NSString *clinicId);
@property (nonatomic, copy) void(^cellDeleteAction)(NSString *clinicId);
@property (nonatomic, copy) void(^cellSaveAction)(NSString *name, NSString *hospCode, NSString *pass);
@property (nonatomic, copy) void(^cellSearchAction)();

@property (weak, nonatomic) IBOutlet UIView *viewNavigation;
@property (weak, nonatomic) IBOutlet UILabel *lbHospital;
@property (weak, nonatomic) IBOutlet UIView *viewSeparatorNavi;
@property (weak, nonatomic) IBOutlet UIButton *btnSaveLinkedAcc;
@property (weak, nonatomic) IBOutlet UIButton *btnExpand;


@property (weak, nonatomic) IBOutlet UIView *viewContent;
@property (weak, nonatomic) IBOutlet PHRTextField *txtLinkedAcc;
@property (weak, nonatomic) IBOutlet PHRTextField *txtLinkedAccPassword;
@property (weak, nonatomic) IBOutlet UIView *viewBoundLinkedAcc;
@property (weak, nonatomic) IBOutlet PHRTextField *txtHospitalName;
@property (weak, nonatomic) IBOutlet UIButton *buttonSearchHospital;
// view action
@property (weak, nonatomic) IBOutlet UIView *viewAction;
@property (weak, nonatomic) IBOutlet UIButton *buttonDelete;

// Action
- (IBAction)actionSave:(id)sender;
- (IBAction)actionDelete:(id)sender;
- (IBAction)actionSearchHospital:(id)sender;
- (IBAction)actionExpand:(id)sender;
- (IBAction)actionLinkedAccTextFieldEndEdit:(id)sender;

- (void)setupWithState:(ClinicCellState)state expanded:(BOOL)expanding;
- (void)setupInfoWithAccount:(ClinicAccount*)account;
- (void)setupInfoWithHospital:(ClinicHospital*)hospital;
- (void)clearData;

@end
