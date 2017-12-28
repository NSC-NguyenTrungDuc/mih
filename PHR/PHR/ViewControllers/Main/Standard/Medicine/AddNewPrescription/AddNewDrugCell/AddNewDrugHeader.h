//
//  AddNewDrugHeader.h
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface AddNewDrugHeader : UITableViewCell

@property (weak, nonatomic) IBOutlet UILabel *lblDrugList;
@property (copy, nonatomic) void (^addDrugCallBack)();
- (IBAction)actionAddNewDrug:(id)sender;
@property (weak, nonatomic) IBOutlet UIButton *btnAddDrug;
@property (nonatomic) BOOL isShowAdd;

@end
