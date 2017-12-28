//
//  ProfileListViewController.m
//  PHR
//
//  Created by BillyMobile on 6/11/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "ProfileListViewController.h"
#import "ProfileTableViewCell.h"

@interface ProfileListViewController ()

@end

static NSString *ProfileCell = @"profile_cell";

@implementation ProfileListViewController{
    NSMutableArray *profiles;
}

- (void)viewDidLoad {
    [super viewDidLoad];
    [self setupNavigationBarTitle:kLocalizedString(@"Choose PHR Profile") titleIcon:nil rightItem:nil];
    
    profiles = [[NSMutableArray alloc] init];
    if ([PHRAppStatus checkCurrentStandardActive]) {
        [profiles addObject:PHRAppStatus.currentStandard];
    }
    if ([PHRAppStatus checkCurrentBabyActive]) {
        [profiles addObject:PHRAppStatus.currentBaby];
    }
    
    self.tableViewProfile.delegate = self;
    self.tableViewProfile.dataSource = self;
    [self.tableViewProfile registerNib:[UINib nibWithNibName:NSStringFromClass([ProfileTableViewCell class]) bundle:nil] forCellReuseIdentifier:ProfileCell];
}

- (void)didReceiveMemoryWarning {
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return profiles.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    ProfileTableViewCell *cell = [self.tableViewProfile dequeueReusableCellWithIdentifier:ProfileCell forIndexPath:indexPath];
    Profile *profile = profiles[indexPath.row];
    cell.lblUserName.text = profile.name;
    cell.lblUserType.text = profile.isBaby ? kLocalizedString(kBabyTitle) : kLocalizedString(kStandardTitle);
    return cell;
}

-(void) tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath{
    Profile *profile = profiles[indexPath.row];
    if(self.addProfileCallBack){
        self.addProfileCallBack(profile);
        [self.navigationController popViewControllerAnimated:YES];
    }
}


/*
#pragma mark - Navigation

// In a storyboard-based application, you will often want to do a little preparation before navigation
- (void)prepareForSegue:(UIStoryboardSegue *)segue sender:(id)sender {
    // Get the new view controller using [segue destinationViewController].
    // Pass the selected object to the new view controller.
}
*/

@end
