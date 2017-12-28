//
//  PatientClinicDataSource.m
//  PHR
//
//  Created by Tran Hoang Ha on 10/10/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "PatientClinicDataSource.h"
#import "PatientClinicTableViewCell.h"

@interface PatientClinicDataSource()
@property (nonatomic, strong) UITableView *tableView;
@property (nonatomic, strong) NSArray *listViewModel;
@end

@implementation PatientClinicDataSource
- (instancetype)initWithTableView:(UITableView *)tableView andListViewModel:(NSArray *)listViewModel {
  self = [super init];
  if (self) {
    self.tableView = tableView;
    self.listViewModel = listViewModel;
  }
  return self;
}

- (NSUInteger)numberOfItemInSections:(NSInteger)section {
  return _listViewModel.count;
}

- (UITableViewCell *)cellForItemAtIndexPath:(NSIndexPath *)indexPath {
  PatientClinicTableViewCell *cell = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([PatientClinicTableViewCell class]) owner:self options:nil] objectAtIndex:0];
  [cell setViewModelForCell:_listViewModel[indexPath.row]];
  return cell;
}
@end

