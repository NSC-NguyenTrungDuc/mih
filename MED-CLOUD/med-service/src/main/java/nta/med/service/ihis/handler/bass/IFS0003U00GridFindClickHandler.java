package nta.med.service.ihis.handler.bass;

import java.util.ArrayList;
import java.util.List;

import javax.annotation.Resource;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.CommonUtils;
import nta.med.data.dao.medi.CommonRepository;
import nta.med.data.dao.medi.ifs.Ifs0002Repository;
import nta.med.data.model.ihis.common.ComboListItemInfo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.BassServiceProto;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00GridFindClickRequest;
import nta.med.service.ihis.proto.BassServiceProto.IFS0003U00GridFindClickResponse;
import nta.med.service.ihis.proto.CommonModelProto;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class IFS0003U00GridFindClickHandler extends ScreenHandler<BassServiceProto.IFS0003U00GridFindClickRequest, BassServiceProto.IFS0003U00GridFindClickResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(IFS0003U00GridFindClickHandler.class);                                    
	@Resource                                                                                                       
	private Ifs0002Repository ifs0002Repository;                                                                    
	@Resource                                                                                                       
	private CommonRepository commonRepository;                                                                    
	                                                                                                                
	@Override   
	@Transactional(readOnly = true)
	public IFS0003U00GridFindClickResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			IFS0003U00GridFindClickRequest request) throws Exception {
  	   	BassServiceProto.IFS0003U00GridFindClickResponse.Builder response = BassServiceProto.IFS0003U00GridFindClickResponse.newBuilder();                      
		List<ComboListItemInfo> list = new ArrayList<ComboListItemInfo>();
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String language = getLanguage(vertx, sessionId);
		String offset = request.getOffset();
  	   	Integer startNum = CommonUtils.getStartNumberPaging(request.getPageNumber(), offset);
		switch (request.getColName()) {
			case "if_code":
				list = ifs0002Repository.getIfs003U03FwkCommonListItem(hospitalCode, request.getCodeType(), request.getFind1(),false, startNum, CommonUtils.parseInteger(offset));
				break;
			case "ocs_code":
				if(!StringUtils.isEmpty(request.getMapGubun())){
					list = commonRepository.getIfs003U03GridFindClickListItem(request.getMapGubun(), hospitalCode, request.getFind1(), language, startNum, CommonUtils.parseInteger(offset));
				}					
				break;
			default:
				break;
		}
		
		if(!CollectionUtils.isEmpty(list)){
			for(ComboListItemInfo item : list){
				CommonModelProto.ComboListItemInfo.Builder info = CommonModelProto.ComboListItemInfo.newBuilder();
				BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
				response.addCboList(info);
			}
		}
		return response.build();
	}                                                                                                            
}