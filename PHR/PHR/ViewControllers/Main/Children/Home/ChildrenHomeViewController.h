//
//  ChildrenHomeViewController.h
//  PHR
//
//  Created by Luong Le Hoang on 9/29/15.
//  Copyright (c) 2015 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "BaseHomeViewController.h"
#import "Base2ViewController.h"

@interface ChildrenHomeViewController : Base2ViewController <UITableViewDelegate, UITableViewDataSource> {
    
}
@property (weak, nonatomic) IBOutlet UIView *viewContent;

@property (weak, nonatomic) IBOutlet UITableView *tableHome;

@property (weak, nonatomic) IBOutlet UIView *viewLoading;
@property (weak, nonatomic) IBOutlet UIButton *btnModeStandard;

- (IBAction)actionChangeToStandardMode:(id)sender;
@end
