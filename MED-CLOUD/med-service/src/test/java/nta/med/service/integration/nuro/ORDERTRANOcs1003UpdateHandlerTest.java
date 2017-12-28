package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class ORDERTRANOcs1003UpdateHandlerTest extends MessageRequestTest{

	@Test
	public void testORDERTRANOcs1003UpdateHandler() throws InterruptedException{
		NuroServiceProto.ORDERTRANOcs1003UpdateRequest.Builder request = NuroServiceProto.ORDERTRANOcs1003UpdateRequest.newBuilder();
		NuroModelProto.ORDERTRANOcs1003UpdateInfo.Builder info = NuroModelProto.ORDERTRANOcs1003UpdateInfo.newBuilder();
		info.setSunabDate("11/11/2011");
		info.setPkocs1003("3153");
		info.setHospCode("K01");
		info.setBunho("01");
		info.setActingDate("11/11/2011");
		info.setGubun("0");
		info.setGwa("0");
		info.setDoctor("0");
		info.setChojae("0");
		
		request.addSaveLayoutItem(info.build());
		
		 sentRequestToMedApp(request.build(), NuroServiceProto.getDescriptor().getOptions().getExtension(Rpc.service));
	}
}
