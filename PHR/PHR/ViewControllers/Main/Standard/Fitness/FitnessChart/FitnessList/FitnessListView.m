//
//  FitnessListView.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "FitnessListView.h"

#define TABLE_VIEW_ITEM_HEIGHT 50

@implementation FitnessListView

NSArray *_listFitnessItem;
static NSString *CellIdentifier = @"TableViewCellIdentifier";

- (void)awakeFromNib {
    [super awakeFromNib];
    [self initData];
    [self initView];
}


- (void)initView {
     self.backgroundColor = [UIColor whiteColor];
     [self initTableView];
}

- (void)initData {
    FitnessListModel *modelStepCount = [[FitnessListModel alloc] initWithImage:[UIImage imageNamed:@"Icon_Step_Count"] andTitle:kLocalizedString(kChartStepCountLowCase)];
    FitnessListModel *modelWalkingRunning = [[FitnessListModel alloc] initWithImage:[UIImage imageNamed:@"Icon_Walking_Running"] andTitle:kLocalizedString(kChartWalkingRunDistanceLowCase)];
    
    _listFitnessItem = [NSArray arrayWithObjects:modelStepCount,modelWalkingRunning, nil];
}

- (void)initTableView {
    self.tableView.delegate = self;
    self.tableView.dataSource = self;
    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    UINib *cell = [UINib nibWithNibName:@"FitnessListTableViewCell" bundle:nil];
    [self.tableView registerNib:cell forCellReuseIdentifier:CellIdentifier];
}

#pragma mark - UITableViewDelegate Methods
- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return _listFitnessItem.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    FitnessListTableViewCell *cell = (FitnessListTableViewCell *)[tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (!cell) {
        cell = [[FitnessListTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    
    FitnessListModel* fitnessListModel = [_listFitnessItem objectAtIndex:indexPath.row];
    cell.imgvThumbnail.image = fitnessListModel.image;
    cell.lbTitle.text = fitnessListModel.title;
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    NSLog(@"%ld",indexPath.row);
    FitnessDetailViewController *fitnessDetailViewController = [[FitnessDetailViewController alloc] initWithNibName:@"FitnessDetailViewController" bundle:nil];
    fitnessDetailViewController.fitnessType = indexPath.row;
    [self.navControl.navigationController pushViewController:fitnessDetailViewController animated:true];
}

@end
