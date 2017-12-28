//
//  AddSelectionView.m
//  PHR
//
//  Created by Nguyen Thanh Tung on 5/18/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "AddSelectionView.h"

#define TABLE_VIEW_ITEM_HEIGHT 50

@implementation AddSelectionView

    NSArray *_listItem;
    static NSString *CellIdentifier = @"TableViewCellIdentifier";

+ (AddSelectionView*)createView: (NSArray*)arrayItem {
    AddSelectionView *screen = [[[NSBundle mainBundle] loadNibNamed:NSStringFromClass([AddSelectionView class]) owner:self options:nil] objectAtIndex:0];
    _listItem = arrayItem;
    return screen;
}

- (void)awakeFromNib {
    self.viewMain.layer.cornerRadius = 3;
    self.viewMain.layer.masksToBounds = true;
    self.backgroundColor = [UIColor colorWithRed:0 green:0 blue:0 alpha:0.6];
    [self.lbTitle setStyleRegularToLabelWithColor:[UIColor colorWithRed:214./255. green:214./255. blue:214./255. alpha:1] andSize:16.0];
    [self.lbTitle setText:kLocalizedString(kAddNew)];
    [self initOnTapOutsideMainView];
    [self initTableView];
}

- (void)initTableView {
    self.tableView.delegate = self;
    self.tableView.dataSource = self;
    self.tableView.separatorStyle = UITableViewCellSeparatorStyleNone;
    UINib *cell = [UINib nibWithNibName:@"AddSelectionTableViewCell" bundle:nil];
    [self.tableView registerNib:cell forCellReuseIdentifier:CellIdentifier];
}

#pragma mark - UITableViewDelegate Methods
- (NSInteger)numberOfSectionsInTableView:(UITableView *)tableView {
    return 1;
}

- (NSInteger)tableView:(UITableView *)tableView numberOfRowsInSection:(NSInteger)section {
    return _listItem.count;
}

- (UITableViewCell *)tableView:(UITableView *)tableView cellForRowAtIndexPath:(NSIndexPath *)indexPath {
    AddSelectionTableViewCell *cell = (AddSelectionTableViewCell *)[tableView dequeueReusableCellWithIdentifier:CellIdentifier];
    if (!cell) {
        cell = [[AddSelectionTableViewCell alloc] initWithStyle:UITableViewCellStyleDefault reuseIdentifier:CellIdentifier];
    }
    cell.selectionStyle = UITableViewCellSelectionStyleNone;
    cell.lbName.text = [_listItem objectAtIndex:indexPath.row];
    if(indexPath.row == _listItem.count - 1){
        cell.viewBottomSeparator.hidden = false;
    } else {
        cell.viewBottomSeparator.hidden = true;
    }
    
    return cell;
}

- (CGFloat)tableView:(UITableView *)tableView heightForRowAtIndexPath:(NSIndexPath *)indexPath {
    return TABLE_VIEW_ITEM_HEIGHT;
}

- (void)tableView:(UITableView *)tableView didSelectRowAtIndexPath:(NSIndexPath *)indexPath {
    NSIndexPath *selectedIndexPath = [tableView indexPathForSelectedRow];
    [[NSNotificationCenter defaultCenter] postNotificationName:kNotifyAddSelectionItem object:selectedIndexPath];
    [self removeFromSuperview];
}

- (void)initOnTapOutsideMainView {
    UITapGestureRecognizer *singleFingerTap =
    [[UITapGestureRecognizer alloc] initWithTarget:self
                                            action:@selector(onTapViewUnder)];
    [self.viewUnder addGestureRecognizer:singleFingerTap];
}

- (void)onTapViewUnder {
    [self hiddenInView];
}

- (void)showInView:(UIView*)parentView {
    self.frame = CGRectMake(0, 0, parentView.bounds.size.width, parentView.bounds.size.height);
    [parentView addSubview:self];
    __block CGRect frame = self.viewMain.frame;
    frame.origin.y = 0;
    self.viewMain.frame = frame;
    [UIView animateWithDuration:0.25 animations:^{
        frame.origin.y = parentView.bounds.size.height - frame.size.height;
        self.viewMain.frame = frame;
    }];
}

- (void)hiddenInView {
    __block CGRect frame = self.viewMain.frame;
    [UIView animateWithDuration:0.25 animations:^{
        frame.origin.y = -150;
        self.viewMain.frame = frame;
    } completion:^(BOOL finished){
        [self removeFromSuperview];
    }];
}

@end
