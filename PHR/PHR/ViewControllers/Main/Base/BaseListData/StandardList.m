//
//  BodyMeasurementList.m
//  PHR
//
//  Created by NextopHN on 5/19/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "StandardList.h"
#import "ListItemTableViewCell.h"

static NSString *listCellIdentifier = @"listItemIdentifier";
@implementation StandardList

- (void)awakeFromNib {
    [super awakeFromNib];
    //[self initTableData];
    self.arrayListItemType = [[NSArray alloc] init];
    [self.tableViewContent registerNib:[UINib nibWithNibName:NSStringFromClass([ListItemTableViewCell class]) bundle:nil] forCellReuseIdentifier:listCellIdentifier];
    self.tableViewContent.separatorStyle = UITableViewCellSeparatorStyleNone;
    self.tableViewContent.dataSource = self;
    self.tableViewContent.delegate = self;
    [self.tableViewContent reloadData];

}

- (void)setupTableData:(NSArray*)arrayItem {
    self.arrayListItemType = arrayItem;
    [self.tableViewContent reloadData];
}


//- (void)initTableData {
//    TableItemModel* modelHeight = [[TableItemModel alloc] initWithImagePath:@"icon_list_height" andTitle:kLocalizedString(kPHHeight)];
//    TableItemModel* modelWeight = [[TableItemModel alloc] initWithImagePath:@"icon_list_weight" andTitle:kLocalizedString(kPHWeight)];
//    TableItemModel* modelBodyFat = [[TableItemModel alloc] initWithImagePath:@"icon_list_body_fat" andTitle:kLocalizedString(kBodyFatPercentage)];
//    TableItemModel* modelBMI = [[TableItemModel alloc] initWithImagePath:@"icon_list_bmi" andTitle:kLocalizedString(kBodyMassIndex)];
//     self.arrayListItemType = @[modelHeight, modelWeight,modelBodyFat,modelBMI];
//}
/*
// Only override drawRect: if you perform custom drawing.
// An empty implementation adversely affects performance during animation.
- (void)drawRect:(CGRect)rect {
    // Drawing code
}
*/
- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return self.arrayListItemType.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    ListItemTableViewCell *cell = [self.tableViewContent dequeueReusableCellWithIdentifier:listCellIdentifier];
    if (!cell) {
        cell = [[ListItemTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:listCellIdentifier];
    }
    
    TableItemModel *item = [self.arrayListItemType objectAtIndex:indexPath.row];
    [cell setupContentWithType:item];

    return  cell;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    if (indexPath.row == ChartContentTypeHeight) {
        if (self.delegate) {
            [self.delegate selectedIndexOfList:ChartContentTypeHeight andList:self];
        }
    }
    if (indexPath.row == ChartContentTypeWeight) {
        if (self.delegate) {
            [self.delegate selectedIndexOfList:ChartContentTypeWeight andList:self];
        }
    }
    if (indexPath.row == ChartContentTypeBodyFat) {
        if (self.delegate) {
            [self.delegate selectedIndexOfList:ChartContentTypeBodyFat andList:self];
        }
    }
    if (indexPath.row == ChartContentTypeBMI) {
        if (self.delegate) {
            [self.delegate selectedIndexOfList:ChartContentTypeBMI andList:self];
        }
    }
}
@end
