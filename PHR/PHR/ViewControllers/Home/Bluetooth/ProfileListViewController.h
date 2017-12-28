//
//  ProfileListViewController.h
//  PHR
//
//  Created by BillyMobile on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "Base2ViewController.h"

@interface ProfileListViewController : Base2ViewController<UITableViewDataSource, UITableViewDelegate>

@property (weak, nonatomic) IBOutlet UITableView *tableViewProfile;
@property (copy, nonatomic) void (^addProfileCallBack)(Profile *profile);

@end
