package nta.med.service.ihis.handler.ocso;

import java.util.Date;
import java.util.List;

import javax.annotation.Resource;

import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.bas.Bas0380Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.OcsoServiceProto;

import org.apache.commons.lang.StringUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.CollectionUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")   
public class OcsOCS1003P01CheckHangSangInfoHandler extends ScreenHandler<OcsoServiceProto.OcsOCS1003P01CheckHangSangInfoRequest, OcsoServiceProto.OcsOCS1003P01CheckHangSangInfoResponse> {                             
	private static final Log LOGGER = LogFactory.getLog(OcsOCS1003P01CheckHangSangInfoHandler.class);                                        
	@Resource                                                                                                       
	private Bas0380Repository bas0380Repository;                                                                    
	                                                                                                                
	@Override
	@Transactional(readOnly = true)
	public OcsoServiceProto.OcsOCS1003P01CheckHangSangInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			OcsoServiceProto.OcsOCS1003P01CheckHangSangInfoRequest request) throws Exception {
		OcsoServiceProto.OcsOCS1003P01CheckHangSangInfoResponse.Builder response = OcsoServiceProto.OcsOCS1003P01CheckHangSangInfoResponse.newBuilder();    
		List<CommonModelProto.CheckHangSangInfo> listInfo = request.getHangSangInfoList();
		if(!CollectionUtils.isEmpty(listInfo)){
			for(CommonModelProto.CheckHangSangInfo info : listInfo){
				Date checkDate = DateUtil.toDate(info.getAppDate(), DateUtil.PATTERN_YYMMDD);
				Date birthDate = DateUtil.toDate(info.getBirthDate(), DateUtil.PATTERN_YYMMDD);
				String result = bas0380Repository.checkHangSangInfo(getHospitalCode(vertx, sessionId), info.getHangmogCode(), info.getSangCode(),
						checkDate, info.getInOutGubun(), info.getGwa(), birthDate);
				if(!StringUtils.isEmpty(result)){
					CommonModelProto.DataStringListItemInfo.Builder builder = CommonModelProto.DataStringListItemInfo.newBuilder();
					builder.setDataValue(result);
					response.addItemInfo(builder);
				}
			}
		}
		return response.build();
	}      

}
