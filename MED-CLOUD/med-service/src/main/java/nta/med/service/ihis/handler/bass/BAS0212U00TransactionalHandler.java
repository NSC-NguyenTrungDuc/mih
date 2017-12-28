package nta.med.service.ihis.handler.bass;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.common.annotation.Route;
import nta.med.core.common.exception.ExecutionException;
import nta.med.core.domain.bas.Bas0212;
import nta.med.core.glossary.DataRowState;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0212Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassModelProto.BAS0212U00GrdItemInfo;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.BAS0212U00TransactionalRequest;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.UpdateResponse;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class BAS0212U00TransactionalHandler extends ScreenHandler<BassServiceProto.BAS0212U00TransactionalRequest, SystemServiceProto.UpdateResponse> {                      
	private static final Log LOGGER = LogFactory.getLog(BAS0212U00TransactionalHandler.class);                                    
	@Resource                                                                                                       
	private Bas0212Repository bas0212Repository;                                                                    
	                                                                                                                
	@Override
	@Route(global = true)
	public UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			BAS0212U00TransactionalRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder();
		List<BAS0212U00GrdItemInfo> listItem = request.getGrdInitList();
		String userId = request.getUserId();
		String language = getLanguage(vertx, sessionId);
		Integer result = null;
		if(!CollectionUtils.isEmpty(listItem)){
			for(BAS0212U00GrdItemInfo item : listItem){
				if(DataRowState.ADDED.getValue().equals(item.getRowState())){
					List<String> tDupCheck = bas0212Repository.getYByGongbiCodeAnDate(item.getGongbiCode(), item.getStartDate(), language);
					if(!CollectionUtils.isEmpty(tDupCheck)){
						response.setMsg(item.getGongbiCode());
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
					result = bas0212Repository.updateBas0212ByGongbiCodeAndEndDate(userId, item.getStartDate(), item.getGongbiCode(), language);
					insertBas0212(item, userId, language);
				} else if(DataRowState.MODIFIED.getValue().equals(item.getRowState())){
					result = bas0212Repository.updateBas0212ByGongbiCodeAndStartDate(userId, item.getEndDate(), item.getLawNo(), 
							item.getGongbiName(), item.getTotalYn(), item.getGongbiJiyeok(), item.getGongbiCode(), item.getStartDate(), language);
					if(result < 0){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				} else if(DataRowState.DELETED.getValue().equals(item.getRowState())){
					result = bas0212Repository.updateBas0212ByGongbiCodeAndEndDateCaseDelete(item.getGongbiCode(), item.getStartDate(), language);
					result = bas0212Repository.deleteBas0210(item.getGongbiCode(), DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD), language);
					if(result < 0){
						response.setResult(false);
						throw new ExecutionException(response.build());
					}
				}
			}
		}
		response.setResult(true);
		return response.build();
	} 
	private void insertBas0212(BAS0212U00GrdItemInfo item, String userId, String language){
		Bas0212 bas0212 =  new Bas0212();
		bas0212.setSysDate(new Date());
		bas0212.setSysId(userId);
		bas0212.setUpdDate(new Date());
		bas0212.setUpdId(userId);
		bas0212.setGongbiCode(item.getGongbiCode());
		bas0212.setStartDate(DateUtil.toDate(item.getStartDate(), DateUtil.PATTERN_YYMMDD));
		bas0212.setEndDate(DateUtil.toDate(item.getEndDate(), DateUtil.PATTERN_YYMMDD));
		bas0212.setLawNo(item.getLawNo());
		bas0212.setGongbiName(item.getGongbiName());
		bas0212.setTotalYn(item.getTotalYn());
		bas0212.setGongbiJiyeok(item.getGongbiJiyeok());
		bas0212.setLanguage(language);
		bas0212Repository.save(bas0212);
	}
}