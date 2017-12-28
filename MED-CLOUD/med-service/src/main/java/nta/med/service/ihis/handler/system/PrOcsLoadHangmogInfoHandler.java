package nta.med.service.ihis.handler.system;

import javax.annotation.Resource;

import nta.med.core.utils.BeanUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.ocs.Ocs0103Repository;
import nta.med.data.model.ihis.system.LoadHangmogInfo;
import nta.med.core.glossary.YesNo;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.CommonModelProto;
import nta.med.service.ihis.proto.SystemServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadHangmogInfoRequest;
import nta.med.service.ihis.proto.SystemServiceProto.PrOcsLoadHangmogInfoResponse;

import org.apache.commons.collections.CollectionUtils;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import java.util.List;

@Service                                                                                                          
@Scope("prototype")                                                                                 
public class PrOcsLoadHangmogInfoHandler extends ScreenHandler<SystemServiceProto.PrOcsLoadHangmogInfoRequest, SystemServiceProto.PrOcsLoadHangmogInfoResponse>{                     
	@Resource                                                                                                       
	private Ocs0103Repository ocs0103Repository;                                                                    
	   
	@Override
    public boolean isValid(SystemServiceProto.PrOcsLoadHangmogInfoRequest request, Vertx vertx, String clientId, String sessionId) {
        if (!StringUtils.isEmpty(request.getAppDate()) && DateUtil.toDate(request.getAppDate(), DateUtil.PATTERN_YYMMDD) == null) {
            return false;
        }
        return true;
    }
	
	@Override
	@Transactional
	public PrOcsLoadHangmogInfoResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			PrOcsLoadHangmogInfoRequest request) throws Exception{                                                                   
  	   	SystemServiceProto.PrOcsLoadHangmogInfoResponse.Builder response = SystemServiceProto.PrOcsLoadHangmogInfoResponse.newBuilder(); 
  	  LoadHangmogInfo hangmogInfo;
  		  hangmogInfo = ocs0103Repository.callPrOcsLoadHangmogInfo(getHospitalCode(vertx, sessionId),
  				  DateUtil.toDate(request.getAppDate(), DateUtil.PATTERN_YYMMDD), 
  				  request.getInputPart(),request.getInputGwa(),request.getHangmogCode(),request.getInputTab());
		if(hangmogInfo != null){
			CommonModelProto.LoadHangmogInfo.Builder info= CommonModelProto.LoadHangmogInfo.newBuilder();
			BeanUtils.copyProperties(hangmogInfo, info, getLanguage(vertx, sessionId));
			if(hangmogInfo.getSuryang()!=null){
				info.setSuryang((String.format("%.0f", hangmogInfo.getSuryang())));
			}
			if(hangmogInfo.getDv()!=null){
				info.setDv((String.format("%.0f", hangmogInfo.getDv())));
			}
			if(hangmogInfo.getLimitSuryang()!=null){
				info.setLimitSuryang((String.format("%.0f", hangmogInfo.getLimitSuryang())));
			}
			if(hangmogInfo.getLimitNalsu()!=null){
				info.setLimitNalsu((String.format("%.0f", hangmogInfo.getLimitNalsu())));
			}
			if(hangmogInfo.getHangmogCode() != null)
			{
				List<String> yjCodes = ocs0103Repository.getYjCode(hangmogInfo.getHangmogCode(), getHospitalCode(vertx, sessionId));
				if(!CollectionUtils.isEmpty(yjCodes) && yjCodes.get(0) != null)
				{
					info.setYjCode(yjCodes.get(0));
				}
			}
			response.addHangmogInfoItem(info);
		}
		return response.build();
	}
}