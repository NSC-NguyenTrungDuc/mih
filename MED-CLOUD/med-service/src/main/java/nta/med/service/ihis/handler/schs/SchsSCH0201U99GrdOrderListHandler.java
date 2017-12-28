package nta.med.service.ihis.handler.schs;


import nta.med.core.domain.sch.Sch0201;
import nta.med.core.infrastructure.socket.handler.ScreenHandler;
import nta.med.core.utils.BeanUtils;
import nta.med.data.dao.medi.ocs.Ocs1003Repository;
import nta.med.data.dao.medi.sch.Sch0201Repository;
import nta.med.data.model.ihis.schs.SchsSCH0201U99GrdOrderListInfo;
import nta.med.service.ihis.proto.SchsModelProto;
import nta.med.service.ihis.proto.SchsServiceProto;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99GrdOrderListRequest;
import nta.med.service.ihis.proto.SchsServiceProto.SchsSCH0201U99GrdOrderListResponse;
import org.springframework.context.annotation.Scope;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.util.StringUtils;
import org.vertx.java.core.Vertx;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.List;


@Service
@Scope("prototype")
public class SchsSCH0201U99GrdOrderListHandler
	extends ScreenHandler<SchsServiceProto.SchsSCH0201U99GrdOrderListRequest, SchsServiceProto.SchsSCH0201U99GrdOrderListResponse> {
	@Resource
	private Sch0201Repository sch0201Repository;
	@Resource
	private Ocs1003Repository ocs1003Repository;
	@Override
	@Transactional(readOnly=true)
	public SchsSCH0201U99GrdOrderListResponse handle(Vertx vertx,
			String clientId, String sessionId, long contextId,
			SchsSCH0201U99GrdOrderListRequest request) throws Exception {
	     SchsServiceProto.SchsSCH0201U99GrdOrderListResponse.Builder  response =  SchsServiceProto.SchsSCH0201U99GrdOrderListResponse.newBuilder();
    	 List<SchsSCH0201U99GrdOrderListInfo> listResult = sch0201Repository.getSchsSCH0201U99GrdOrderListInfo(getHospitalCode(vertx, sessionId), getLanguage(vertx, sessionId), request.getFFlag(),
				 request.getFBunho(), request.getFFkocs(), request.getFReserStatus(), request.getFReserGubun(), request.getFReserPart(), request.getIsMyClinnic());


		List<SchsSCH0201U99GrdOrderListInfo> schsSCH0201U99GrdOrderListInfos = new ArrayList<>();

		for(SchsSCH0201U99GrdOrderListInfo schsSCH0201U99GrdOrderListInfo :  listResult)
		{

			if(request.getIsMyClinnic().equals("N") )
			{
				if(schsSCH0201U99GrdOrderListInfo.getPksch0201Out() == null)
				{
					schsSCH0201U99GrdOrderListInfos.add(schsSCH0201U99GrdOrderListInfo);
				}
				else if(schsSCH0201U99GrdOrderListInfo.getPksch0201Out() != null)
				{
					Sch0201 sch0201 = sch0201Repository.findByOutHospCodeAndPksch0201(getHospitalCode(vertx, sessionId),
							schsSCH0201U99GrdOrderListInfo.getPksch0201Out());
					if(sch0201 != null && !ocs1003Repository.isCompleteOrder(sch0201.getHospCode(), sch0201.getFkocs()))
					{
						schsSCH0201U99GrdOrderListInfos.add(schsSCH0201U99GrdOrderListInfo);
					}
				}
			}


			if(request.getIsMyClinnic().equals("Y"))
			{
				schsSCH0201U99GrdOrderListInfos.add(schsSCH0201U99GrdOrderListInfo);
			}
		}

		if(schsSCH0201U99GrdOrderListInfos != null && !schsSCH0201U99GrdOrderListInfos.isEmpty()){
	    	 for(SchsSCH0201U99GrdOrderListInfo item : schsSCH0201U99GrdOrderListInfos){
	    		 SchsModelProto.SchsSCH0201U99GrdOrderListInfo.Builder info = SchsModelProto.SchsSCH0201U99GrdOrderListInfo.newBuilder();
	    		 	BeanUtils.copyProperties(item, info, getLanguage(vertx, sessionId));
	    			if (!StringUtils.isEmpty(item.getPksch0201())) {
	    				info.setPksch0201(String.format("%.0f",item.getPksch0201()));
	    			}
	    			response.addOrderList(info);
	    	 }
	     }
	     return response.build();
	}
}
