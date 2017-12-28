//
//  AddNewRemiderFooter.h
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface AddNewRemiderFooter : UITableViewCell
@property (weak, nonatomic) IBOutlet UIButton *btnAddNewDrug;
- (IBAction)actionAddNewRemider:(id)sender;
@property (copy, nonatomic) void (^addRemiderCallBack)();

@end
