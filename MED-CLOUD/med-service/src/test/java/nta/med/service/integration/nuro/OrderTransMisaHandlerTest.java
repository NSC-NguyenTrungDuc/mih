package nta.med.service.integration.nuro;

import org.junit.Test;

import nta.med.common.remoting.rpc.protobuf.Rpc;
import nta.med.service.ihis.proto.NuroModelProto;
import nta.med.service.ihis.proto.NuroServiceProto;
import nta.med.service.integration.MessageRequestTest;

public class OrderTransMisaHandlerTest extends MessageRequestTest{

	@Test
	public void tesOrderTransMisaHandler() throws Exception{
		
/*		NuroModelProto.OrderTransMisaHangmogInfo misaHangmogInfoBuilder1 = NuroModelProto.OrderTransMisaHangmogInfo
				.newBuilder()
				.setHangmogCode("641110022")
				.setHangmogCodeExt("")
				.build();
		
		NuroModelProto.OrderTransMisaSangCodeInfo misaSangCodeInfo1 = NuroModelProto.OrderTransMisaSangCodeInfo
				.newBuilder()
				.setSangCode("0000999")
				.setSangCodeExt("")
				.build(); */
		
		NuroServiceProto.OrderTransMisaRequest request = NuroServiceProto.OrderTransMisaRequest
				.newBuilder()
				.setBunho("000000039")
				.setHopsCode("K01")
				.setPkout1001("962,0")
				//.addLstHangmog(misaHangmogInfoBuilder1)
				//.addLstSangcode(misaSangCodeInfo1)
				.build();
		
        sentRequestToMedApp(request, NuroServiceProto.getDescriptor().
                getOptions().getExtension(Rpc.service));
	}
}
