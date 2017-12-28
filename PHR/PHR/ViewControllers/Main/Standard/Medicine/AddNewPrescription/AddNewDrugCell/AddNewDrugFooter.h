//
//  AddNewDrugFooter.h
//  PHR
//
//  Created by BillyMobile on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface AddNewDrugFooter : UITableViewCell

- (IBAction)actionAddNewDrug:(id)sender;
@property (weak, nonatomic) IBOutlet UIButton *btnAddNewDrug;
@property (copy, nonatomic) void (^addDrugCallBack)();

@end
