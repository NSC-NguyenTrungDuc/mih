//
//  UploadImagesCollectionViewCell.h
//  PHR
//
//  Created by Dao Xuan Tu on 11/22/16.
//  Copyright © 2016 Sofia. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface UploadImagesCollectionViewCell : UICollectionViewCell
@property (weak, nonatomic) IBOutlet UIImageView *imgUpload;
@property (weak, nonatomic) IBOutlet UIButton *btnClose;
@property (weak, nonatomic) IBOutlet UIButton *btnAdd;
@property (copy, nonatomic) void (^deleteImageCallBack)();
@end
