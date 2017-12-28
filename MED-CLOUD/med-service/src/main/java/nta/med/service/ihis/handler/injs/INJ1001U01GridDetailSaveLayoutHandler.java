package nta.med.service.ihis.handler.injs;

import java.sql.Timestamp;
import java.util.Date;
import java.util.List;

import javax.annotation.Resource;
import org.springframework.transaction.annotation.Transactional;

import nta.med.core.common.exception.ExecutionException;
import nta.med.core.utils.CommonUtils;
import nta.med.core.utils.DateUtil;
import nta.med.data.dao.medi.inj.Inj1001Repository;
import nta.med.data.dao.medi.inj.Inj1002Repository;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.service.ihis.proto.InjsModelProto.InjsINJ1001U01DetailListItemInfo;
import nta.med.service.ihis.proto.InjsServiceProto;
import nta.med.service.ihis.proto.SystemServiceProto;

import org.apache.commons.collections.CollectionUtils;
import org.apache.commons.logging.Log;
import org.apache.commons.logging.LogFactory;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

@Service                                                                                                          
@Scope("prototype")    
@Transactional
public class INJ1001U01GridDetailSaveLayoutHandler extends ScreenHandler<InjsServiceProto.INJ1001U01GridDetailSaveLayoutRequest, SystemServiceProto.UpdateResponse> {                     
	private static final Log LOGGER = LogFactory.getLog(INJ1001U01GridDetailSaveLayoutHandler.class);                                    
	@Resource                                                                                                       
	private Inj1001Repository inj1001Repository;   
	@Resource
	private Inj1002Repository inj1002Repository;

	@Override
	public SystemServiceProto.UpdateResponse handle(Vertx vertx, String clientId,
			String sessionId, long contextId,
			InjsServiceProto.INJ1001U01GridDetailSaveLayoutRequest request) throws Exception {
		SystemServiceProto.UpdateResponse.Builder response = SystemServiceProto.UpdateResponse.newBuilder(); 
		String hospitalCode = getHospitalCode(vertx, sessionId);
		String temp1 = null;
		String temp2 = null;
		Integer resultUpdate = null;
		for(InjsINJ1001U01DetailListItemInfo info : request.getItemInfoList()){
			//check
			 List<Timestamp> listObject = inj1001Repository.getInjsINJ1001U01OrderDateList(hospitalCode, info.getPkinj1002());
	            if(!CollectionUtils.isEmpty(listObject)) {
	            	for(Timestamp item : listObject) {
	            		//response.addOrderDate(item == null ? "" : DateUtil.toString(item, DateUtil.PATTERN_YYMMDD));
	            		if(item != null && item.toString().length() > 9){
	            			temp1 = item.toString().substring(0, 10).replace("/", "").replace("-","");
	            			temp2 = info.getActingDateChar().replace("/","").replace("-","");
	            			if(StringUtils.isEmpty(temp2)){
	            				temp2 = "30001231";
	            			}
	            		}
	            		if(CommonUtils.parseInteger(temp1) > CommonUtils.parseInteger(temp2)){
	            			response.setResult(false);
	              			throw new ExecutionException(response.build());
	            		}
	            	}
	            }
	        //update
	            Double pkinj1002 = CommonUtils.parseDouble(info.getPkinj1002());
	            if(!StringUtils.isEmpty(info.getActingFlag() != null && "Y".equals(info.getActingFlag()))){
	            	Date actingDate = DateUtil.toDate(info.getActingDateChar(), DateUtil.PATTERN_YYMMDD);
	            	resultUpdate = inj1002Repository.updateINJ1001U01(info.getActingFlag(), actingDate, DateUtil.toString(new Date(), DateUtil.PATTERN_HHMM),
		            		info.getTonggyeCode(), info.getMixGroup(), request.getUpdId(), new Date(), info.getJujongja(), info.getSilsiRemark(), hospitalCode, pkinj1002);
	            }else{
	            	resultUpdate = inj1002Repository.updateINJ1001U01(info.getActingFlag(), null, null,
		            		info.getTonggyeCode(), info.getMixGroup(), request.getUpdId(), new Date(), null, info.getSilsiRemark(), hospitalCode, pkinj1002);
	            }
		}
		 response.setResult(resultUpdate != null && resultUpdate > 0);
		return response.build();
	}                                                                                                                 
}