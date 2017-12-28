package nta.med.service.ihis.handler.bass;

import java.util.Date;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.domain.bas.Bas0110;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0110Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0110U00GrdJohapListItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0110U00TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Transactional
@Service                                                                                                          
@Scope("prototype")                                                                                 
public class BAS0110U00TransactionalHandler extends ScreenHandler<BassServiceProto.BAS0110U00TransactionalRequest, SystemServiceProto.UpdateResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(BAS0110U00TransactionalHandler.class);                                        
	@Resource                                                                                                       
	private Bas0110Repository bas0110Repository;                                                                    
	                                                                                                                
	@Override    
	@Route(global = true)
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0110U00TransactionalRequest request) throws Exception {
  	   	SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
  	   	String language = getLanguage(vertx, sessionId);
  	   	if(!CollectionUtils.isEmpty(request.getListInfoList())) {
			for(BAS0110U00GrdJohapListItemInfo item : request.getListInfoList()){
				if(item.getRowState().equalsIgnoreCase(DataRowState.ADDED.getValue())){
					response.setResult(insertBas0110(item, request.getUserId(), language));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.MODIFIED.getValue())){
					response.setResult(updateBas0110(item, request.getUserId(), language));
				}else if(item.getRowState().equalsIgnoreCase(DataRowState.DELETED.getValue())){
					response.setResult(deleteBas0110(item, request.getUserId(), language));
				}
			}
  	   	}
		return response.build();
	}        
	public boolean insertBas0110(BAS0110U00GrdJohapListItemInfo item, String userId, String language){
		Bas0110 bas0110 = new Bas0110();
		bas0110.setSysDate(new Date());
		bas0110.setSysId(userId);
		bas0110.setUpdDate(new Date());
		bas0110.setUpdId(userId);
		bas0110.setJohap(item.getJohap());
		if(!StringUtils.isEmpty(item.getStartDate())){
			bas0110.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
		}
		bas0110.setEndDate(DateUtil.toDate("9998/12/31", DateUtil.PATTERN_YYMMDD));
		bas0110.setJohapName(item.getJohapName());
		bas0110.setJohapGubun(item.getJohapGubun());
		bas0110.setZipCode1(item.getZipCode1());
		bas0110.setZipCode2(item.getZipCode2());
		bas0110.setAddress(item.getAddress());
		bas0110.setTel(item.getTel());
		bas0110.setLawNo(item.getLawNo());
		bas0110.setDodobuhyeunNo(item.getDodobuhyeunNo());
		bas0110.setBoheomjaNo(item.getBoheomjaNo());
		bas0110.setCd(item.getCd());
		bas0110.setGiho(item.getGiho());
		bas0110.setRemark(item.getRemark());
		bas0110.setCheckDigitYn(item.getCheckDigitYn());
		bas0110.setLanguage(language);
		bas0110Repository.save(bas0110);
		return true;
				
	}
	
	public boolean updateBas0110(BAS0110U00GrdJohapListItemInfo item, String userId, String language){
		if(bas0110Repository.updateBas0110U00TransactionModified(
				userId, 
				item.getJohapName(), 
				item.getZipCode1(), 
				item.getZipCode2(),
				item.getAddress(), 
				item.getTel(), 
				item.getGiho(),
				item.getRemark(), 
				item.getCheckDigitYn(), 
				item.getJohap(), 
				DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), 
				item.getJohapGubun(),
				language)>0){
			return true;
		}else{
			return false;
		}
	}
	
	public boolean deleteBas0110(BAS0110U00GrdJohapListItemInfo item, String userId, String language){
		if(bas0110Repository.deleteBas0110U00TransactionDeleted(
				item.getJohap(),
				DateUtil.toDate(item.getStartDate(),
				DateUtil.PATTERN_YYMMDD),item.getJohapGubun(),
				language)>0){
			return true;
		}else{
			return false;
		}
	}
}