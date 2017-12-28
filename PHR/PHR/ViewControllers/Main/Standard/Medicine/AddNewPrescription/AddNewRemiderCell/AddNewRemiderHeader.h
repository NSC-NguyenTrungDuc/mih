//
//  AddNewRemiderHeader.h
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface AddNewRemiderHeader : UITableViewCell
//@property (weak, nonatomic) IBOutlet UIButton *btnExpant;
@property (weak, nonatomic) IBOutlet UILabel *lblRemider;

@property (copy, nonatomic) void (^addRemiderCallBack)();
- (IBAction)actionAddNewAlarm:(id)sender;
@property (weak, nonatomic) IBOutlet UIButton *btnAddAlarm;

//- (IBAction)actionExpant:(id)sender;
@end
