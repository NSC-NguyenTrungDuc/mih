//
//  UploadImagesCollectionViewCell.m
//  PHR
//
//  Created by Dao Xuan Tu on 11/22/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import "UploadImagesCollectionViewCell.h"

@implementation UploadImagesCollectionViewCell

- (IBAction)OnClickBtnClose:(id)sender {
  self.deleteImageCallBack();
}

- (void)awakeFromNib {
  [super awakeFromNib];
  self.btnAdd.userInteractionEnabled = NO;
  self.imgUpload.layer.cornerRadius = 8;
  self.imgUpload.layer.masksToBounds = YES;
}

@end
