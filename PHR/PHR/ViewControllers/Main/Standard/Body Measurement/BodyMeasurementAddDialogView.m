//
//  BodyMeasurementAddDialogView.m
//  PHR
//
//  Created by NextopHN on 5/21/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "BodyMeasurementAddDialogView.h"
#import "ListItemTableViewCell.h"

#define cellHeight 40.0
#define cellHeaderHeight 60.0
static NSString *listCellIdentifier = @"listItemIdentifier";

@implementation BodyMeasurementAddDialogView

/*
 // Only override drawRect: if you perform custom drawing.
 // An empty implementation adversely affects performance during animation.
 - (void)drawRect:(CGRect)rect {
 // Drawing code
 }
 */
- (void)awakeFromNib {
    [super awakeFromNib];
    self.backgroundColor = [[UIColor blackColor] colorWithAlphaComponent:0.0];
    self.viewUnderTableMenu.backgroundColor = [[UIColor blackColor] colorWithAlphaComponent:0.6];
    [self setupTapGesture];
    self.arrayMenuItem = [[NSArray alloc] init];
    self.tableMenuItem.dataSource = self;
    self.tableMenuItem.delegate = self;
    
    [self.tableMenuItem registerNib:[UINib nibWithNibName:NSStringFromClass([ListItemTableViewCell class]) bundle:nil] forCellReuseIdentifier:listCellIdentifier];
    self.tableMenuItem.separatorStyle = UITableViewCellSeparatorStyleNone;
    self.tableMenuItem.layer.cornerRadius = 6.0;
    self.tableMenuItem.clipsToBounds = YES;
    
    [self.tableMenuItem reloadData];
    [self recalculateHeightForTableView];
}

- (void)setupTableData:(NSArray*)arrayItem {
    self.arrayMenuItem = arrayItem;
    [self.tableMenuItem reloadData];
    [self recalculateHeightForTableView];
}

- (void)recalculateHeightForTableView {
    self.constraintTableHeight.constant = cellHeight * _arrayMenuItem.count + cellHeaderHeight;
}

- (void)setupTapGesture{
    UITapGestureRecognizer *tap = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(close)];
    [self.viewUnderTableMenu addGestureRecognizer:tap];
}

- (void)close{
    [self removeFromSuperview];
}

- (void)doNothing{
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return _arrayMenuItem.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    ListItemTableViewCell *cell = [self.tableMenuItem dequeueReusableCellWithIdentifier:listCellIdentifier];
    if (!cell) {
        cell = [[ListItemTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:listCellIdentifier];
    }
    TableItemModel *item = [self.arrayMenuItem objectAtIndex:indexPath.row];
    [cell setupContentWithType:item];
    cell.layer.borderWidth = 0.5;
    cell.layer.borderColor = [UIColor lightGrayColor].CGColor;
    return  cell;
}

#pragma mark - TableView Delegate
- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return cellHeight;
}

- (CGFloat)tableView:(UITableView *)tableView heightForHeaderInSection:(NSInteger)section{
    return cellHeaderHeight;
}

- (UIView *)tableView:(UITableView *)tableView viewForHeaderInSection:(NSInteger)section {
    UIView * view = [[UIView alloc]initWithFrame:CGRectMake(0, 0, self.tableMenuItem.bounds.size.width, cellHeaderHeight)];
    UILabel *label = [[UILabel alloc] initWithFrame:view.bounds];
    [view addSubview:label];
    label.text = kLocalizedString(kAddNew);
    label.textAlignment = NSTextAlignmentCenter;
    label.font = [UIFont fontWithName:@"HelveticaNeue-Medium" size:18.0];
    label.textColor = [PHRUIColor colorFromHex:@"#d6d6d6" alpha:1.0];
    
    UITapGestureRecognizer *tap = [[UITapGestureRecognizer alloc] initWithTarget:self action:@selector(close)];
    [view addGestureRecognizer:tap];
    
    return view;
}
- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    if (self.delegate) {
        [self.delegate selectedIndexMenuItem:indexPath.row andList:self];
    }
    [self close];
}
@end
